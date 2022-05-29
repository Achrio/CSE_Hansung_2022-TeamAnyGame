using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject monster33;
    public Transform monsterta;
    public Transform door1;//1Ãþ 1¹ø 
    public Transform door2;
    public Transform door3;//1Ãþ 3¹ø 
    public Transform door4;

    public Transform door3a;//1Ãþ2¹ø
    public Transform door3b;

    public Transform door5; //3Ãþ1¹ø
    public Transform door6;

    public Transform door7; //2Ãþ1¹ø
    public Transform door8;

    public Transform door5a; //2Ãþ2¹ø
    public Transform door5b;

    public Transform door6a; //2Ãþ3¹ø
    public Transform door6b;



    public Transform elem1; //¿¤·¹º£ÀÌÅÍ
    public Transform doorm1; //¿¤·¹º£ÀÌÅÍ

    public bool action1 = false;//1Ãþ 1¹ø 

    public bool action2 = false;//1Ãþ 3¹ø
    public bool action3a = false;//1Ãþ 2¹ø
    public bool action3b = false;

    public bool action3 = false; //3Ãþ 1¹ø
    public bool action4 = false; //2Ãþ 1¹ø

    public bool action5a = false; //2Ãþ 1¹ø¹æ ¸ó½ºÅÍ 
    public bool action5b = false; //2Ãþ 2¹ø¹æ ¹®Å¬¸¯

    public bool action6a = false; //2Ãþ 3¹ø¹æ 
    public bool action6b = false;

    public bool eletop1 = true;
    public bool eletop2 = true;

    public bool actionelem1t = false;
    public bool actionelem1b = false;
    public bool actionm1 = false;
    public bool actionm2 = false;


    private bool[] keys = new bool[3] { false, false, false };
    private bool[] key2 = new bool[3] { false, false, false };
    private bool[] key3 = new bool[3] { false, false, false };
    private bool i = true;
    private bool j = true;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (action1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                i = true;
                if (i)
                {
                    door1.SendMessage("Play");
                    i = false;
                }
            }
        }
        if (action1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                j = true;
                if (j)
                {
                    door2.SendMessage("Play");
                    j = false;
                }
            }
        }

        if (action2)
        {
            door3.SendMessage("Play");
        }

        if (action2)
        {
            door4.SendMessage("Play");
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
                Invoke("Tricka", 8f);
            }
        }
        if (keys[0] && keys[1])
        {
            door3a.SendMessage("Play");
            door3b.SendMessage("Play");
        }

        if (actionelem1t)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if(eletop1)
                    elem1.SendMessage("Play");
                else if(!eletop1)
                    elem1.SendMessage("Play2");
            }
        }
        if (actionelem1b)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (eletop1)
                    elem1.SendMessage("Play2");
                else if (!eletop1)
                    elem1.SendMessage("Play");
            }
        }
        if (actionm1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (eletop1)
                    doorm1.SendMessage("Play");
                else if (!eletop1)
                    doorm1.SendMessage("Play2");
            }
        }
        if (actionm2)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (eletop1)
                    doorm1.SendMessage("Play2");
                else if (!eletop1)
                    doorm1.SendMessage("Play");
            }
        }
        if (action3)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                door5.SendMessage("Play");
            }
        }
        if (action3)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                door6.SendMessage("Play");
            }
        }
        if (action4)
        {
            door7.SendMessage("Play");
        }

        if (action4)
        {
            door8.SendMessage("Play");
        }
        if (action5a)
        {
            if (key2[1])
            {
                key2[0] = true;
            }
        }
        if (action5b)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                key2[1] = true;
            }
        }
        if (key2[0] && key2[1])
        {
            door5a.SendMessage("Play");
            door5b.SendMessage("Play");
        }
        if (action6a)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (key3[1])
                {
                    key3[0] = true;
                }
            }
        }
        if (action6b)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                key3[1] = true;
                Invoke("Trickb", 8f);
            }
        }
        if (key3[0] && key3[1])
        {
            door6a.SendMessage("Play");
            door6b.SendMessage("Play");
        }
    }
    public void monster1()
    {
        action2 = true;
    }
    public void monster2()
    {
        action4 = true;
    }
    public void monster3()
    {
        action5a = true;
    }
    private void Tricka()
    {
        keys[1] = false;
    }
    private void Trickb()
    {
        key3[1] = false;
    }
    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "ActionZone")
        {
            action1 = true;
        }
        if (_col.gameObject.tag == "ActionZone2")
        {
            action3 = true;
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
            action5b = true;
        }
        if (_col.gameObject.tag == "ActionZone6a")
        {
            action6a = true;
        }
        if (_col.gameObject.tag == "ActionZone6b")
        {
            action6b = true;
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
            action3 = false;
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
            action5b = false;
        }
        if (_col.gameObject.tag == "ActionZone6a")
        {
            action6a = false;
        }
        if (_col.gameObject.tag == "ActionZone6b")
        {
            action6b = false;
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
