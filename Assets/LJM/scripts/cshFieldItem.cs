using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshFieldItem : MonoBehaviour
{
    public cshItem item;
    public SpriteRenderer image;

    public void SetItem(cshItem _item)
    {
        item.itemName = _item.itemName;
        item.itemImg = _item.itemImg;
        item.itemType = _item.itemType;

        image.sprite = item.itemImg;
    }

    public cshItem GetItem() 
    {
        return item;
    }

    public void DestroyItem() 
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
