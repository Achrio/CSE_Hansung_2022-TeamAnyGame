using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordcol : MonoBehaviour
{
    void swordremove()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        //Destroy(gameObject, 0.1f);
    }
    void swords()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
