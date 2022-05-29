using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
    private Animator unichan_ani;
    private Rigidbody chan_rigid;
    private bool isGrounded = false;//아직못씀

    public float movespeed = 4.0f;
    public float jumppower = 4.5f;
    public int jumpitem;
    public Transform sword;
    public bool died;
    public bool damagecheck = true;

    public AudioClip audiojump;
    public AudioClip audiorun;
    public AudioClip audiodead;
    public AudioClip audioattack;
    public AudioClip audioattack2;
    public AudioClip audiodmgd;
    AudioSource audioSource;

    public int attacks;

    void Start()
    {
        chan_rigid = GetComponent<Rigidbody>();
        unichan_ani = GetComponent<Animator>();
        attacks = 0;
        jumpitem = 2;
    }
    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Jump();
        //�ø������� �ٴڿ� �������� �ǰ� �ؾߵɰŰ�����.....
        Move();
        attack();
        Died();
    }
     private void attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            attacks++;
            unichan_ani.SetBool("slash", true);
            audioSource.clip = audioattack;
            audioSource.Play();
            if (attacks == 2)
            {
                unichan_ani.SetBool("slash1", true);
                audioSource.clip = audioattack2;
                audioSource.Play();
            }
            if (attacks == 3)
            {
                unichan_ani.SetBool("slash2", true);
                audioSource.clip = audioattack;
                audioSource.Play();
            }
            if(attacks > 3)
            {
                attacks = 0;
            }

        }
    }
    void unattack()
    {
        unichan_ani.ResetTrigger("attack");
        unichan_ani.ResetTrigger("attack1");
    }
    void attack_zero()
    {
        attacks = 0;
        unichan_ani.ResetTrigger("slash");
        unichan_ani.ResetTrigger("slash1");
        unichan_ani.ResetTrigger("slash2");
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpitem > 0)
            {
                chan_rigid.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
                if (jumpitem == 2)
                {
                    unichan_ani.SetBool("isground", false);
                    audioSource.clip = audiojump;
                    audioSource.Play();
                }
                if (jumpitem == 1)
                {
                    unichan_ani.SetBool("doublej", true);
                    audioSource.clip = audiojump;
                    audioSource.Play();
                }
                jumpitem--;

            }
        }
        if (chan_rigid.velocity.y > 0.0f)
        {
            unichan_ani.SetBool("dojump", true);
        }
    }
    void dmgdchk()
    {
        damagecheck = true;
    }
    public void dmgd()
    {
        GameManager.instance.curHPUpdate(-1);
        damagecheck = false;
        audioSource.clip = audiodmgd;
        audioSource.Play();
        Invoke("dmgdchk", 1.0f);
    }
    public void Died()
    {
        if(GameManager.instance) {
            if (GameManager.instance.HP <= 0) {
                unichan_ani.SetBool("died", true);
                Invoke("FadeOut", 3f);
                Invoke("Wait2sec", 5f);
                died = true;
                audioSource.clip = audiodead;
                audioSource.Play();
                if (died)
                {
                    sword.SendMessage("swordremove");
                    Debug.Log("swordoff");
                }
            }
        }
    }
    void FadeOut() {
        FadeScreen.instance.fadeout();
    }
    void Wait2sec()
    {
        died = false;
        FadeScreen.instance.fadein();
        GameManager.instance.HP = 15;
        DataManager.instance.DataSave();
        DataManager.instance.DataLoad();
        SceneLoadingManager.LoadScene("LobbyScene");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            unichan_ani.SetBool("isground", true);
            unichan_ani.SetBool("dojump", false);
            unichan_ani.SetBool("doublej", false);
            jumpitem = 2;
        }
    }
    private void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        Vector3 movex = Vector3.right * xMove;

        Vector3 getVel = movex.normalized;

        transform.LookAt(transform.position + getVel);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            unichan_ani.SetBool("runok", true);
            unichan_ani.SetFloat("MoveSpeed", getVel.magnitude);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                getVel *= 2.0f;
                audioSource.clip = audiorun;
                audioSource.Play();
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            unichan_ani.SetBool("runok", true);
            unichan_ani.SetFloat("MoveSpeed", getVel.magnitude);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                getVel *= 2.0f;
                audioSource.clip = audiorun;
                audioSource.Play();
            }
        }

        unichan_ani.SetFloat("MoveSpeed", getVel.magnitude);

        transform.Translate(getVel * movespeed * Time.deltaTime, Space.World);

        if (xMove == 0)
        {
            unichan_ani.SetBool("runok", false);
        }
    }
    GameObject gameObject1;
    void OnTriggerEnter(Collider _col)
    {
        
        if (_col.gameObject.tag == "actionzone1")
        {
            GetComponent<CapsuleCollider>().isTrigger = true;
        }
        if (_col.gameObject.tag == "horn")
        {
            unichan_ani.SetBool("damage", true);
        }
        if (_col.gameObject.tag == "moster")
        {
            if (damagecheck == true)
            {
                unichan_ani.SetBool("damage", true);
                dmgd();
            }
        }
    }
    void OnTriggerExit(Collider _col)
    {
        
        if (_col.gameObject.tag == "actionzone1")
        {
            GetComponent<CapsuleCollider>().isTrigger = false;
        }
        if (_col.gameObject.tag == "horn")
        {
            unichan_ani.SetBool("damage", false);
        }
        if (_col.gameObject.tag == "moster")
        {
            unichan_ani.SetBool("damage", false);
        }
    }
}
