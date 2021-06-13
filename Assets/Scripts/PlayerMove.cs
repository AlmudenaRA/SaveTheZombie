using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public bool isGrounded;
    Rigidbody2D rigidbody2D;
    private Animator animator;
    private bool grounded;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {        
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       
    }

    void FixedUpdate()
    {       

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);
        }        
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }

        Debug.DrawRay(transform.position, Vector3.down * 1.0f, Color.red);
        //Comprobar si está en el aire o en el suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.0f))
        {
            grounded = true;
        }
        else grounded = false;

        if (Input.GetKey("w") && grounded)
        {
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
            rigidbody2D.AddForce(Vector2.up * jumpForce); //up => x = 0 ; y = 1
        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    isGrounded = true;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    isGrounded = false;
    //}
}
