using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    private Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }
    // Update is called once per frame
    void LateUpdate() 
    {
        tr.position = new Vector3(
            target.position.x,
            target.position.y+1f,
            target.position.z-3.0f);
        
    }
}
