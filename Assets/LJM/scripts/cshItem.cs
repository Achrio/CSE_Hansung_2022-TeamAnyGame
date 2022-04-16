using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    itemA,
    itemB,
    itemC,
}

[System.Serializable]
public class cshItem
{
    

    public ItemType itemType;
    public string itemName;
    public Sprite itemImg;

    public bool Use()
    {
        return false;
    }
}
