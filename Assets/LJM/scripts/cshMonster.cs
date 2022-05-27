using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cshMonster : MonoBehaviour
{
    public enum Type { Slime, Turtle, Mage, Plant, Orc, Skeleton, Spider, Boss };
    public Type enemyType;
    public int maxHP;
    public int curHP;
    public Transform target;
    public bool isChase;
    public bool isAttack;
    public bool isDead;
    public bool isMetrobania = true;
    public BoxCollider meleeArea;
    public GameObject bullet;
    public GameObject keyplayer;
    

    public Rigidbody rigidbody;
    public CapsuleCollider capsuleCollider;
    public Material mat;
    public NavMeshAgent nav;
    public Animator animator;
    public bool playerin = false;
    public bool playerout = false;
    public Transform monsterzone;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player").gameObject.transform;

        if (enemyType != Type.Boss)
        {
            //Invoke("ChaseStart", 2);
        }
    }

    public void MonsterOn()
    {
        Debug.Log("monsteron");
        playerin = true;

    }
    public void MonsterOff()
    {
        Debug.Log("monsteroff");
        playerout = true;
    }

    void ChaseStart()
    {
        isChase = true;
        animator.SetBool("isWalk", true);
    }

    void Update()
    {
        if (playerin)
        {
            Debug.Log("monsteryes");
            ChaseStart();
            playerin = false;
        }
        if (playerout)
        {
            Debug.Log("monsterNO");
            isChase = false;
            animator.SetBool("isWalk", false);
            playerout = false;
        }
        if (nav.enabled && enemyType != Type.Boss)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }
    }

    void FreezeVelocity()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    void Targeting()
    {
        if (!isDead && enemyType != Type.Boss) {
            float targetRadius = 1f;
            float targetRange = 1f;


            switch (enemyType)
            {
                case Type.Slime:
                    targetRadius = 1f;
                    targetRange = 1f;
                    break;
                case Type.Turtle:
                    targetRadius = 0.75f;
                    targetRange = 3f;
                    break;
                case Type.Mage:
                    targetRadius = 0.5f;
                    targetRange = 5f;
                    break;
                case Type.Plant:
                    targetRadius = 1f;
                    targetRange = 1f;
                    break;
                case Type.Orc:
                    targetRadius = 1f;
                    targetRange = 1f;
                    break;
                case Type.Skeleton:
                    targetRadius = 1f;
                    targetRange = 1f;
                    break;
                case Type.Spider:
                    targetRadius = 0.75f;
                    targetRange = 3f;
                    break;
            }

        switch (enemyType)
        {
            case Type.Slime:
                targetRadius = 1f;
                targetRange = 1f;
                break;
            case Type.Turtle:
                targetRadius = 0.75f;
                targetRange = 3f;
                break;
            case Type.Mage:
                targetRadius = 0.5f;
                targetRange = 5f;
                break;
            case Type.Plant:
                targetRadius = 1f;
                targetRange = 1f;
                break;
            case Type.Orc:
                targetRadius = 1f;
                targetRange = 1f;
                break;
            case Type.Skeleton:
                targetRadius = 1f;
                targetRange = 1f;
                break;
            case Type.Spider:
                targetRadius = 0.75f;
                targetRange = 3f;
                break;
        }

            RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, targetRadius,
                transform.forward, targetRange, LayerMask.GetMask("Player"));
            

            if (raycastHits.Length > 0 && !isAttack)
            {
                Debug.Log("attackok");
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Attack()
    {
        Debug.Log("Attacking");
        isChase = false;
        isAttack = true;
        animator.SetBool("isAttack", true);

        switch (enemyType)
        {
            case Type.Slime:

                yield return new WaitForSeconds(0.2f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.6f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(0.03f);
                break;
            case Type.Turtle:
                yield return new WaitForSeconds(0.1f);
                rigidbody.AddForce(transform.forward * 5, ForceMode.Impulse);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.73f);
                rigidbody.velocity = Vector3.zero;
                meleeArea.enabled = false;

                animator.SetBool("isAttack", false);
                yield return new WaitForSeconds(3f);
                break;
            case Type.Mage:
                yield return new WaitForSeconds(1.45f);
                GameObject instantBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z),
                    Quaternion.Euler(transform.rotation.x * 90, transform.rotation.y, transform.rotation.z * 180));
                Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
                rigidBullet.velocity = transform.forward * 10;

                yield return new WaitForSeconds(0.53f);
                break;
            case Type.Plant:
                yield return new WaitForSeconds(0.6f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(1f);
                meleeArea.enabled = false;

                animator.SetBool("isAttack", false);
                yield return new WaitForSeconds(1f);
                break;
            case Type.Orc:
                yield return new WaitForSeconds(0.5f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(1.5f);
                meleeArea.enabled = false;

                animator.SetBool("isAttack", false);
                yield return new WaitForSeconds(2f);
                break;
            case Type.Skeleton:
                yield return new WaitForSeconds(0.1f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.47f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(0.1f);
                break;
            case Type.Spider:
                yield return new WaitForSeconds(0.1f);
                rigidbody.AddForce(transform.forward * 5, ForceMode.Impulse);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.9f);
                rigidbody.velocity = Vector3.zero;
                meleeArea.enabled = false;

                animator.SetBool("isAttack", false);
                yield return new WaitForSeconds(3f);
                break;
        }

        isChase = true;
        isAttack = false;
        animator.SetBool("isAttack", false);
    }

    private void FixedUpdate()
    {
        Targeting();
        FreezeVelocity();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            curHP -= 10;
            Vector3 reactVec = transform.position - other.transform.position;

            if(!isDead)
                StartCoroutine(OnDamage(reactVec));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            curHP -= 10;
            Vector3 reactVec = transform.position - collision.gameObject.transform.position;

            if (!isDead)
                StartCoroutine(OnDamage(reactVec));
        }

        if(collision.gameObject.tag == "Throwed") {
            curHP -= 1000;
            Vector3 reactVec = transform.position - collision.gameObject.transform.position;

            if (!isDead)
                StartCoroutine(OnDamage(reactVec));
        }

        
    }


    IEnumerator OnDamage(Vector3 reactVec)
    {
        if(!isDead)
            mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (curHP > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            capsuleCollider.enabled = false;
            mat.color = Color.gray;
            isChase = false;
            isDead = true;
            if(nav) nav.enabled = false;
            animator.SetTrigger("doDie");

            reactVec = reactVec.normalized;
            reactVec += Vector3.up;
            rigidbody.AddForce(reactVec * 5, ForceMode.Impulse);

            rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            if (enemyType != Type.Boss)
                Destroy(gameObject, 2);

            if(isMetrobania) monsterzone.SendMessage("zoneoff");

            Destroy(gameObject, 2);
            if(isMetrobania) keyplayer.SendMessage("destroyed");

        }
    }
}
