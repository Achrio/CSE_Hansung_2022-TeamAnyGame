using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshStore : MonoBehaviour
{
    public GameObject Store_UI;

    public GameObject[] itemObj;
    public int[] itemPrice;
    public Transform[] itemPos;
    public Text message;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Store_UI.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Store_UI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Store_UI.SetActive(true);
        }
    }

    public void Exit() 
    {
        Store_UI.SetActive(false);
    }

    public void Buy(int index) 
    {
        int price = itemPrice[index];
        if (price > cshPlayerInv.coin)
        {
            message.text = "돈이\n 부족합니다";
            return;
        }

        cshPlayerInv.coin -= price;

        Instantiate(itemObj[index], itemPos[index].position, itemPos[index].rotation);

        message.text = "구매 성공";
    }
}
