using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float horizontal;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //controla si el pj va a la izd o drcha

        //Si va a la izquierda, cambia su posición x para que el pj vaya a la izq
        if (horizontal < 0.0f) transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(0.5f, 0.5f, 1.0f); //si va a la dcha mira a la dcha
        animator.SetBool("running", horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 1.0f, Color.red);
        //Comprobar si está en el aire o en el suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.0f))
        {
            grounded = true;
        }
        else grounded = false;

        //Salta si pulsa la tecla W
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();

            animator.SetBool("jump", true);
            animator.SetBool("running", false);

        }

        if (!grounded)
        {           
            animator.SetBool("jump", false);
        }
    }

    private void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce); //up => x = 0 ; y = 1
       
    }

    private void FixedUpdate()
    {
        //Modificar la velocidad
        rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
    }
}
