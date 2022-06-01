using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clears : MonoBehaviour
{
    public GameObject flare;
    void OnTriggerEnter(Collider _col)
    {

        if (_col.gameObject.tag == "Player")
        {
            Instantiate(flare);
        }
    }
}
