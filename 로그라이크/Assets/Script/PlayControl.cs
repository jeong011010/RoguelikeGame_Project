using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    float moveX;
    bool isGround = false;
    bool doubleJumpState = false;

    Rigidbody2D rb;

    [Header("이동속도 조절")]
    [SerializeField][Range(0f,50f)] float moveSpeed = 5f;

    [Header("점프 강도")]
    [SerializeField][Range(100f,800f)] float jumpForce = 400f;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();

        //transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }

    void Movement(){
        if(rb.velocity.y == 0) isGround = true;
        else isGround = false;

        if(isGround) doubleJumpState = true;

        if(isGround&&Input.GetButtonDown("Jump")) JumpAddForce();
        else if(doubleJumpState&&Input.GetButtonDown("Jump")){
            JumpAddForce();
            doubleJumpState = false;
        }
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
            
        rb.velocity = new Vector2(moveX, rb.velocity.y);

        /*if(Input.GetKeyDown(KeyCode.Space)){
            if(rb.velocity.y==0){
                rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Force);
            }
        }*/
    }

    void JumpAddForce(){
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce);
    }

}
