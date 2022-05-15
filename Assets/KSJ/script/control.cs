using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
    private Animator unichan_ani;
    private Rigidbody chan_rigid;
    private bool isGrounded = false;

    public float movespeed = 4.0f;
    public float jumppower = 10.0f;
    public float hp = 2.0f;


    public int attacks;

    void Start()
    {
        chan_rigid = GetComponent<Rigidbody>();
        unichan_ani = GetComponent<Animator>();
        attacks = 0;
        hp = 2.0f;
    }

    void Update()
    {
        Jump();
        //컬리더에서 바닥에 있을떄만 되게 해야될거같은데.....
        Move();
        attack();
    }
     private void attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            attacks++;
            unichan_ani.SetBool("slash", true);
            if (attacks == 2)
            {
                unichan_ani.SetBool("slash1", true);
            }
            if (attacks == 3)
            {
                unichan_ani.SetBool("slash2", true);
            }
            if(attacks > 3)
            {
                attacks = 0;
            }

        }
        if (Input.GetKey(KeyCode.C))
        {
            unichan_ani.SetTrigger("attack");
            Invoke("unattack", 60f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.V))
        {
            unichan_ani.SetTrigger("attack1");
            Invoke("unattack", 1f * Time.deltaTime);
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
            if (!isGrounded)
            {
                isGrounded = true;
                chan_rigid.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
                unichan_ani.SetBool("isground", false);
            }
        }
        if (chan_rigid.velocity.y > 0)
        {
            unichan_ani.SetBool("dojump", true);
        }
    }
    public void dmgd()
    {
        hp--;
    }
    public void Died()
    {
        if (hp <= 0)
        {
            unichan_ani.SetBool("died", true);
            Invoke("Wait2sec", 5f);
            
        }
    }
    void Wait2sec()
    {
        SceneManager.LoadScene("metro");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
            unichan_ani.SetBool("isground", true);
            unichan_ani.SetBool("dojump", false);
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
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            unichan_ani.SetBool("runok", true);
            unichan_ani.SetFloat("MoveSpeed", getVel.magnitude);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                getVel *= 2.0f;
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

    }
}
