using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public static float ItemPickUp;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    private float runspeed =8;
    [SerializeField]
    private float jumpheight = 11;

    void Start()
    {

        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        bool pressedKey = false;

        if (Input.GetKey("w") && isGrounded)
        {
            pressedKey = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpheight);
            animator.Play("Player_jump");
        }
        if (Input.GetKey("d"))
        {
            pressedKey = true;
            rb2d.velocity = new Vector2(runspeed, rb2d.velocity.y);
            if (isGrounded)
                animator.Play("Player_run");
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a"))
        {
            pressedKey = true;
            rb2d.velocity = new Vector2(-runspeed, rb2d.velocity.y);
            if (isGrounded)
                animator.Play("Player_run");
            spriteRenderer.flipX = true;
        }
        if (pressedKey == false)
        {
            if (isGrounded)
                animator.Play("Player_idle");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }


    }
    
}


