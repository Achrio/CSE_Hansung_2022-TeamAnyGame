using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosterdis : MonoBehaviour
{
    public Transform monster;
    public bool monsteron;
    public bool monsteroff;

    // Update is called once per frame
    void Update()// ���� �����̴� �� ������ �ִ� ��ũ��Ʈ
    {
        if (monsteron == true)
        {
            monster.SendMessage("MonsterOn");
            monsteron = false;
        }
        if (monsteroff == true)
        {
            if(monster)
                monster.SendMessage("MonsterOff");
            monsteroff = false;
        }
    }
    void zoneoff()
    {
        Destroy(gameObject, 2);
    }
    void OnTriggerEnter(Collider _col)
    {
        if(_col.gameObject.tag == "Player")
        {
            monsteron = true;
            monsteroff = false;
        }
    }
    void OnTriggerExit(Collider _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            monsteron = false;
            monsteroff = true;
        }

    }
}
