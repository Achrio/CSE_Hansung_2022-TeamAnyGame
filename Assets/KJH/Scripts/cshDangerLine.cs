using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshDangerLine : MonoBehaviour
{
    LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        lr.startColor = new Color(1, 0, 0, 0.7f);
        lr.endColor = new Color(1, 0, 0, 0.7f);
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
