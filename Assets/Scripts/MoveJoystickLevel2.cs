using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoystickLevel2 : MonoBehaviour
{
    private float horizontalMove = 0f;

    public Joystick joystick;
    public float speed = 2;
    public float jumpSpeed = 1.25f;
    public float runSpeedHorizontal = 2;

    Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
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
        if (horizontalMove > 0) //mover hacia la derecha
        {
            spriteRenderer.flipX = false;
            animator.SetBool("running", true);

        }
        else if (horizontalMove < 0) //mover hacia la izquierda
        {
            spriteRenderer.flipX = true;
            animator.SetBool("running", true);
        }
        else
        {

            animator.SetBool("running", false);
        }

        Debug.DrawRay(transform.position, Vector3.down * 0.2f, Color.red);
        //Comprobar si está en el aire o en el suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
        {
            grounded = true;
        }
        else grounded = false;


        if (grounded == false)
        {
            animator.SetBool("jump", true);
            animator.SetBool("running", false);

        }

        if (grounded == true)
        {
            animator.SetBool("jump", false);
        }
    }

    private void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * speed;

    }

    public void Jump()
    {
        if (grounded == true)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        }

    }
}
