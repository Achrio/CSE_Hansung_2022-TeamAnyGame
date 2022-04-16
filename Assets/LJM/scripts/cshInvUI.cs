using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshInvUI : MonoBehaviour
{
    cshPlayerInv inv;

    public GameObject inventoyUI;
    bool activeInventory = false;

    private List<cshItem> itemList;

    public cshSlot[] slots;
    public Transform slotHolder;

    // Start is called before the first frame update
    void Start()
    {

        inventoyUI.SetActive(activeInventory);

        itemList = new List<cshItem>();

        slots = slotHolder.GetComponentsInChildren<cshSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoyUI.SetActive(activeInventory);
            Debug.Log(itemList.Count);
        }
    }

    void redraw() 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            //slots[i].removeSlot();
        }
        //for (int i = 0; i < inv.itemList.Count; i++)
        {
            //slots[i].removeSlot();
        }
    }
}
