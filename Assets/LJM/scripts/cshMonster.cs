using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cshMonster : MonoBehaviour
{
    public enum Type { A, B, C };
    public Type enemyType;
    public int maxHP;
    public int curHP;
    public Transform target;
    public bool isChase;
    public bool isAttack;
    public BoxCollider meleeArea;

    Rigidbody rigidbody;
    CapsuleCollider capsuleCollider;
    Material mat;
    NavMeshAgent nav;
    Animator animator;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        Invoke("ChaseStart", 2);
    }

    void ChaseStart() 
    {
        isChase = true;
        animator.SetBool("isWalk", true);
    }

    void Update()
    {
        if (nav.enabled)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }
    }

    void FreezeVelocity()
    {
        rigidbody.angularVelocity = Vector3.zero;
    }

    void Targeting() 
    {
        float targetRadius = 1f;
        float targetRange = 1f;

        switch (enemyType) 
        {
            case Type.A:
                targetRadius = 1f;
                targetRange = 1f;
                break;
            case Type.B:
                targetRadius = 0.75f;
                targetRange = 3f;
                break;
            case Type.C:
                targetRadius = 1f;
                targetRange = 1f;
                break;
        }

        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, targetRadius,
            transform.forward, targetRange, LayerMask.GetMask("Player"));

        if (raycastHits.Length > 0 && !isAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        animator.SetBool("isAttack", true);

        switch (enemyType)
        {
            case Type.A:
                yield return new WaitForSeconds(0.2f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(1f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(1f);
                break;
            case Type.B:
                yield return new WaitForSeconds(0.1f);
                rigidbody.AddForce(transform.forward * 10, ForceMode.Impulse);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.5f);
                rigidbody.velocity = Vector3.zero;
                meleeArea.enabled = false;

                animator.SetBool("isAttack", false);
                yield return new WaitForSeconds(3f);
                break;
            case Type.C:
                yield return new WaitForSeconds(0.2f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.5f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(0.5f);
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
        if (other.tag == "Player")
        {
            curHP -= 10;
            Vector3 reactVec = transform.position - other.transform.position;

            StartCoroutine(OnDamage(reactVec));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            curHP -= 10;
            Vector3 reactVec = transform.position - collision.gameObject.transform.position;

            StartCoroutine(OnDamage(reactVec));
        }
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (curHP > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color = Color.gray;
            isChase = false;
            nav.enabled = false;
            animator.SetTrigger("doDie");

            reactVec = reactVec.normalized;
            reactVec += Vector3.up;
            rigidbody.AddForce(reactVec * 5, ForceMode.Impulse);

            Destroy(gameObject, 2);
        }
    }
}
