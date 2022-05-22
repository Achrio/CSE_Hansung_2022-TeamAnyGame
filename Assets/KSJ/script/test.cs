using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Transform target;
    public Transform target2;
    private bool up,down;

    public void Play()
    {
        up = true;
        down = false;
    }
    public void Play2()
    {
        down = true;
        up = false;
    }
    
    // Update is called once per frames
    void Update()
    {
        if (up)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 1.0f * Time.deltaTime);

        }
        if (down)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.position, 1.0f * Time.deltaTime);

        }

    }
}
