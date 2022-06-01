using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    public GameObject line;
    public GameObject missile;
    public Transform FirePos;


    void MissileShot()
    {
        Instantiate(missile, FirePos.transform.position, FirePos.transform.rotation);
    }

    void OnTriggerEnter(Collider player) {
        if(player.gameObject.tag == "Player") {
            Instantiate(line, FirePos.transform.position, FirePos.transform.rotation);
            Invoke("MissileShot", 5f);
        }
    }
}
