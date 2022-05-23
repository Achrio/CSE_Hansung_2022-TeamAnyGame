using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerShield : MonoBehaviour
{
    public bool isShield;
    public int PlayerHp; //�÷��̾� ü�� �ӽ�
    public int damage; //������ �ӽ�

    // Start is called before the first frame update
    void Start()
    {
        isShield = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("PlayerShield").GetComponent<MeshRenderer>().enabled = isShield;
        if (isShield)
        {
            if (damage != 0)
            {
                damage = 0;
                isShield = false;
            }
        }
        else 
        {
            PlayerHp = PlayerHp - damage;
            damage = 0;
        }
    }
}
