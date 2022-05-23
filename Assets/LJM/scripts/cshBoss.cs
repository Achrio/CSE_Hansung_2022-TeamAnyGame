using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cshBoss : cshMonster
{
    public GameObject rock;
    public GameObject dragon;
    public Transform firepos;
    public Transform rockpos01;
    public Transform rockpos02;
    public Transform rockpos03;
    public Transform rockpos04;

    Vector3 lookVec;
    Vector3 tauntVec;
    bool isLook;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        nav.isStopped = true;
        StartCoroutine(Think());
    }

    // Start is called before the first frame update
    void Start()
    {
        isLook = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) {
            GetComponent<BoxCollider>().enabled = false;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            StopAllCoroutines();
            return;
        }
        if (isLook) {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            lookVec = new Vector3(h, 0, v) * 1f;
            //transform.LookAt(target.position + lookVec);
        }
        nav.SetDestination(target.position);
        nav.isStopped = false;
        bossTargeting();
    }

    void bossTargeting()
    {
        if (!isDead)
        {
            float targetRadius = 5f;
            float targetRange = 5f;

            RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, targetRadius,
                transform.forward, targetRange, LayerMask.GetMask("Player"));

            if (raycastHits.Length > 0)
            {
                nav.isStopped = true;
            }
        }
    }

    IEnumerator Think() {
        yield return new WaitForSeconds(0.1f);

        int rndAction = Random.Range(0,5);
        switch (rndAction) {
            case 0:
            case 1:
                StartCoroutine(Atk01());
                break;
            case 2:
            case 3:
                StartCoroutine(Atk02());
                break;
            case 4:
                StartCoroutine(Taunt());
                break;
        }
    }

    IEnumerator Atk01() {
        animator.SetTrigger("doAtk01");
        meleeArea.enabled = true;
        yield return new WaitForSeconds(0.7f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(2.3f);
        StartCoroutine(Think());

    }
    IEnumerator Atk02()
    {
        animator.SetTrigger("doAtk02");
        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = true;
        yield return new WaitForSeconds(0.45f);
        meleeArea.enabled = false;
        GameObject rock01 = Instantiate(rock, rockpos01.position, rockpos01.rotation);
        GameObject rock02 = Instantiate(rock, rockpos02.position, rockpos02.rotation);
        GameObject rock03 = Instantiate(rock, rockpos03.position, rockpos03.rotation);
        GameObject rock04 = Instantiate(rock, rockpos04.position, rockpos04.rotation);

        yield return new WaitForSeconds(2.25f);
        StartCoroutine(Think());

    }
    IEnumerator Taunt()
    {
        animator.SetTrigger("doTaunt");
        yield return new WaitForSeconds(0.75f);
        GameObject dragon01 = Instantiate(dragon, firepos.position, firepos.rotation);
        cshBossBullet bossBullet01 = dragon01.GetComponent<cshBossBullet>();
        bossBullet01.Target = target;

        yield return new WaitForSeconds(1f);
        GameObject dragon02 = Instantiate(dragon, firepos.position, firepos.rotation);
        cshBossBullet bossBullet02 = dragon02.GetComponent<cshBossBullet>();
        bossBullet02.Target = target;

        yield return new WaitForSeconds(1f);
        GameObject dragon03 = Instantiate(dragon, firepos.position, firepos.rotation);
        cshBossBullet bossBullet03 = dragon03.GetComponent<cshBossBullet>();
        bossBullet03.Target = target;

        yield return new WaitForSeconds(2.25f);
        StartCoroutine(Think());

    }
}
