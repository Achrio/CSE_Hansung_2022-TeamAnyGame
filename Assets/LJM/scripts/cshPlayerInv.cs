using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerInv : MonoBehaviour
{
    public static int coin;

    private List<cshItem> itemList;

    public delegate void onSloteCountChange(int val);
    public onSloteCountChange onSlotCountChange;

    public int slotCnt;

    // Start is called before the first frame update
    void Start()
    {
        slotCnt = 4;
        coin = 500;

        itemList = new List<cshItem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool AddItem(cshItem item) 
    {
        itemList.Add(item);
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FieldItem"))
        {
            cshFieldItem fieldItem = collision.gameObject.GetComponent<cshFieldItem>();
            if (AddItem(fieldItem.GetItem()))
                fieldItem.DestroyItem();
        }
    }
}
