using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshItemDB : MonoBehaviour
{
    public static cshItemDB instance;
    private void Awake()
    {
        instance = this;
    }
    public List<cshItem> itemDB = new List<cshItem>();

    public GameObject fieldItem;
    public Vector3[] pos;

    public void Start()
    {
        
    }

}
