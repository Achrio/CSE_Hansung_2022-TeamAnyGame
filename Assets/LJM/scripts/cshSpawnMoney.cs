using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSpawnMoney : MonoBehaviour
{
    public GameObject obj;
    public int Max;
    public float interval = 5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", 0.1f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObj()
    {
        Instantiate(obj, transform.position, transform.rotation);
    }

}
