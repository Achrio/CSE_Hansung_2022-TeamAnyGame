using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBullet : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Monster")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            //플레이어 접촉시 실행
        }
    }
}
