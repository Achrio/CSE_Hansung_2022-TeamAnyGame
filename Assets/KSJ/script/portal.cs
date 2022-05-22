using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public Transform portal1s;
    public Transform portal2s;
    public Transform portal3s;
    public bool portal1 = false;
    public bool portal2 = false;
    public bool portal3 = false;
    // Update is called once per frame
    void Update()
    {
        if (portal1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                gameObject.transform.position = portal1s.position;
            }
        }
        if (portal2)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                gameObject.transform.position = portal2s.position;
            }
        }
        if (portal3)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                gameObject.transform.position = portal3s.position;
            }
        }
    }
    void OnTriggerEnter(Collider _col)
    {

        if (_col.gameObject.tag == "portal")
        {
            portal1 = true;
        }
        if (_col.gameObject.tag == "portal2")
        {
            portal2 = true;
        }
        if (_col.gameObject.tag == "portal3")
        {
            portal3 = true;
        }
    }
    void OnTriggerExit(Collider _col)
    {

        if (_col.gameObject.tag == "portal")
        {
            portal1 = false;
        }
        if (_col.gameObject.tag == "portal2")
        {
            portal2 = false;
        }
        if (_col.gameObject.tag == "portal3")
        {
            portal3 = false;
        }
    }
}
