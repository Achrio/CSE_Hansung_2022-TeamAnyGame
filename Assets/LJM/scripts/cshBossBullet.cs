using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cshBossBullet : MonoBehaviour
{
    public Transform Target;
    public GameObject Effect;
    NavMeshAgent nav;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(Target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Monster")
        {
            GameObject effect = Instantiate(Effect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(effect, 0.5f);
        }
        if (other.tag == "Player")
        {
            //플레이어 접촉시 실행
            //GameObject.Find("PlayerShield").GetComponent<cshPlayerShield>().damage = 10;
        }
    }
}
