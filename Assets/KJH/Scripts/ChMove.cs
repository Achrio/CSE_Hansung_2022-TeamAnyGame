using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChMove : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 5f;
    public int jumpCount;
    public float jumpzonePower = 2f;
    public int isJump;
    public bool dirRight = true;
    int isRight = 1;

    public Transform wallChk;
    public float wallchkDistance;
    public LayerMask w_Layer;
    bool isWall;
    public float wallSpeed;
    public float wallJumpPower;
    public bool isWallJump = false;

    public float climbingSpeed = 3f;
    bool isLadder;

    public float dashSpeed = 20.0f;
    public float dashTime = 0.0f;
    bool isDash;
    public int dashCount;
  
    Rigidbody rigid;

    Vector3 movement;
    public float horizontalMove;
    float verticalMove;
    [SerializeField] bool isJumping;
    bool jumpZone;

 

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        isJump = jumpCount;
    }

    void Update()
    {
        RayCast();
        GetInput();
        Run();
        Jump();
        JumpZone();
        Wall();
        Ladder();
        Dash();
    }

    void RayCast()
    {
        isWall = Physics.Raycast(wallChk.position, Vector2.right * isRight, wallchkDistance, w_Layer);
    }
    void GetInput()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        isJumping = Input.GetButtonDown("Jump");
        isDash = Input.GetButtonDown("Dash");
    }
    void Run()
    {
        movement.Set(horizontalMove, 0, verticalMove);
        movement = movement.normalized * speed * Time.deltaTime;
        if (!isWallJump)
        {
            rigid.velocity = new Vector3(horizontalMove * speed, rigid.velocity.y, rigid.velocity.z);
        }
        if(!isWallJump)
        if (horizontalMove > 0.0f && !dirRight)
        {
            ChangeDir();
        }
        else if (horizontalMove < 0.0f && dirRight)
        {
            ChangeDir();
        }
    }
    void Dash()
    {
        //(????????? ??????) UI ???????????? ???????????? ?????? ?????? static?????? cshTimer??? count ??????,
        //             GameManager??? count ???????????? ?????? ??????
        if (isDash && GameObject.Find("GameManager").GetComponent<cshTimer>().curDashcount > 0)
        {
            StartCoroutine(InDash());
            GameObject.Find("GameManager").GetComponent<cshTimer>().curDashcount--;

            if(dashUI.Dash)
                    dashUI.Dash.curDashUpdate(GameObject.Find("GameManager").GetComponent<cshTimer>().curDashcount);
        }
    }
    IEnumerator InDash()
    {
        float startTime = Time.time;

        
            while (Time.time < startTime + dashTime)
            {
                rigid.AddForce(Vector3.right * dashSpeed * isRight, ForceMode.Impulse);
                yield return null; 
            }
      
    }

    void Jump()
    {
        if (isJumping && isJump > 0)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump --;
        }
    }
    void JumpZone()
    {
        if (jumpZone)
        {
            rigid.AddForce(Vector3.up * jumpPower * jumpzonePower, ForceMode.Impulse);
            jumpZone = false;
        }
    }
    void Wall()
    {
        if(isWall)
        {
            isWallJump = false;
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y * wallSpeed, rigid.velocity.z);
            if (isJumping)
            {
                isWallJump = true;
                Invoke("FreezeX", 0.3f);
                rigid.velocity = new Vector3(-isRight*wallJumpPower, 1.1f * wallJumpPower, rigid.velocity.z);
                ChangeDir();
            }
        }
    }

    void Ladder()
    {
        if(isLadder)
        {
            rigid.useGravity = false;
            rigid.velocity = new Vector3(rigid.velocity.x, verticalMove * climbingSpeed , rigid.velocity.z);
        }
        else
        {
            rigid.useGravity = true;
        }

    }
    void FreezeX()
    {
        isWallJump = false;
    }
    void ChangeDir()
    { 
            dirRight = !dirRight;
            isRight = isRight*-1;
            transform.Rotate(Vector3.up, 180.0f, Space.World);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = jumpCount;
        }
        if (collision.gameObject.tag == "JumpZone")
        {
            jumpZone = true;
            isJump = 0;
        }
        if (collision.gameObject.tag == "Ladders")
        {
            isLadder = true;
            isJump = jumpCount;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ladders")
        {
            isLadder = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(wallChk.position, Vector3.right * isRight * wallchkDistance);

    }
}
