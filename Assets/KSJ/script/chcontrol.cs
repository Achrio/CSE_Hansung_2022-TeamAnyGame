using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chcontrol : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    private move movement3D;

    private void Awake()
    {
        movement3D = GetComponent<move>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movement3D.MoveTo(new Vector3(x, 0, z));

        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.JumpTo();
        }
    }
    void OnTriggerEnter(Collider _col)
    {

        if (_col.gameObject.tag == "actionzone1")
        {
            GetComponent<CharacterController>().isTrigger = true;
        }
    }
    void OnTriggerExit(Collider _col)
    {

        if (_col.gameObject.tag == "actionzone1")
        {
            GetComponent<CharacterController>().isTrigger = false;
        }

    }
}
    

