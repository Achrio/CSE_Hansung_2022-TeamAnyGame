using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacks : MonoBehaviour
{
    void OnTriggerEnter(Collider _col)
    {
        if(_col.gameObject.tag == "moster")
            GetComponent<BoxCollider>().isTrigger = false;
    }
    void OnTriggerExit(Collider _col)
    {
         GetComponent<BoxCollider>().isTrigger = true;

    }
}
