using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform door1;
    public Transform door2;
    public Transform door3;
    public Transform door4;
    public Transform elem1;
    public Transform doorm1;
    public Transform doorm2;

    public bool action1 = false;
    public bool action2 = false;
    public bool action3a = false;
    public bool action3b = false;
    public bool action4 = false;
    public bool actionelem1t = false;
    public bool actionelem1b = false;
    public bool actionm1 = false;
    public bool actionm2 = false;


    private bool[] keys = new bool[3] { false, false, false };
 
    // Update is called once per frame
    void Update()
    {
        if (action1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                door1.SendMessage("Play");
            }
        }
        if (action2)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                door2.SendMessage("Play");
            }
        }
        if (action3a)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (keys[1])
                {
                    keys[0] = true;
                }
            }
        }
        if (action3b)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                keys[1] = true;
                Invoke("Tricka", 3f);
            }
        }
        if (action4)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                door4.SendMessage("Play");
            }
        }
        if (keys[0] && keys[1])
        {
            door3.SendMessage("Play");
        }
        if (actionelem1t)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                elem1.SendMessage("Play");
            }
        }
        if (actionelem1b)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                elem1.SendMessage("Play2");
            }
        }
        if (actionm1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                doorm1.SendMessage("Play");
            }
        }
        if (actionm2)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                doorm2.SendMessage("Play");
            }
        }
    }
    private void Tricka()
    {
        keys[1] = false;
    }
    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "ActionZone")
        {
            action1 = true;
        }
        if (_col.gameObject.tag == "ActionZone2")
        {
            action2 = true;
        }
        if (_col.gameObject.tag == "ActionZone3-1")
        {
            action3a = true;
        }
        if (_col.gameObject.tag == "ActionZone3-2")
        {
            action3b = true;
        }
        if (_col.gameObject.tag == "ActionZone4")
        {
            action4 = true;
        }
        if (_col.gameObject.tag == "eletop")
        {
            actionelem1t = true;
        }
        if (_col.gameObject.tag == "elebot")
        {
            actionelem1b = true;
        }
        if (_col.gameObject.tag == "ActionZonem1")
        {
            actionm1 = true;
        }
        if (_col.gameObject.tag == "ActionZonem2")
        {
            actionm2 = true;
        }
    }
    void OnTriggerExit(Collider _col)
    {
        if (_col.gameObject.tag == "ActionZone")
        {
            action1 = false;
        }
        if (_col.gameObject.tag == "ActionZone2")
        {
            action2 = false;
        }
        if (_col.gameObject.tag == "ActionZone3-1")
        {
            action3a = false;
        }
        if (_col.gameObject.tag == "ActionZone3-2")
        {
            action3b = false;
        }
        if (_col.gameObject.tag == "ActionZone4")
        {
            action4 = false;
        }
        if (_col.gameObject.tag == "eletop")
        {
            actionelem1t = false;
        }
        if (_col.gameObject.tag == "elebot")
        {
            actionelem1b = false;
        }
        if (_col.gameObject.tag == "ActionZonem1")
        {
            actionm1 = false;
        }
        if (_col.gameObject.tag == "ActionZonem2")
        {
            actionm2 = false;
        }
    }
}
