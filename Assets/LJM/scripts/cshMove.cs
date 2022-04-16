using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMove : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 5f;

    Rigidbody rigidbody;

    Vector3 movement;
    float horizontalMove;
    float verticalMove;
    bool isJumping;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
            isJumping = true;
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
    }

    void Run() 
    {
        movement.Set(horizontalMove, 0, verticalMove);
        movement = movement.normalized * speed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);
    }

    void Jump() 
    {
        if (!isJumping)
            return;

        rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isJumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Platform")
            GetComponent<CapsuleCollider>().isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Platform")
            GetComponent<CapsuleCollider>().isTrigger = false;
    }
}
