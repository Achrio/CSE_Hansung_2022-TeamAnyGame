using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    public GameObject line;
    public GameObject missile;
    public Transform FirePos;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown (0))
        {
            Instantiate(line, FirePos.transform.position, FirePos.transform.rotation);
            Invoke("MissileShot", 5f);
        }
    }
    void MissileShot()
    {
        Instantiate(missile, FirePos.transform.position, FirePos.transform.rotation);
    }
}
