using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshShieldItem : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 30f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //플레이어 접촉시 실행
            GameObject.Find("PlayerShield").GetComponent<cshPlayerShield>().isShield = true;
        }
    }
}
