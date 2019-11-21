using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed;

    //Vector3 movement;
    //Vector3 moveDirection;
    Vector3 move; 

    float h;
    float v;
    //Rigidbody playerRigidbody;

    void Awake()
    {
        //playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //h = Input.GetAxisRaw("Horizontal");
        //v = Input.GetAxisRaw("Vertical");

        //moveDirection = (h * transform.right + v * transform.forward).normalized;

        //Move(h,v);
        Move();
        //Jump(h, v); ...TODO
    }

    /*void Move(float h, float v)      //UNDER CONSTRUCTION KEEPO
    {
        Vector3 yVelFix = new Vector3(0, playerRigidbody.velocity.y, 0);
        //playerRigidbody.AddForce(moveDirection, ForceMode.Acceleration); //Problem: Player is capsule not cube.
        //playerRigidbody.velocity = moveDirection * speed * Time.deltaTime *100; //Problem: Cant use velocity on kinematic rigidbody
        //playerRigidbody.velocity += yVelFix;                                    
        
    }
    if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            playerRigidbody.AddForce(jump* jumpForce, ForceMode.Impulse);
        }
        */
Vector2 GetInput()
    {
        return new Vector2
        {
            y = Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            x = Input.GetAxis("Vertical") * speed * Time.deltaTime
        };
    } 

    void Move()
    {
        transform.Translate(-GetInput().x, 0.0f, GetInput().y, Space.World);
    }
    
}
