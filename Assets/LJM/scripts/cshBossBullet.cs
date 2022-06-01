using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cshBossBullet : MonoBehaviour
{
    public Transform Target;
    public GameObject Effect;
    NavMeshAgent nav;
    public Rigidbody rb;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector3.left * 500f);
    }

    // Update is called once per frame
    void Update()
    {
        //nav.SetDestination(Target.position);
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Monster" && other.tag != "ground")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            GameManager.instance.curHPUpdate(-1);
        }
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(Effect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(effect, 2f);
    }
}
