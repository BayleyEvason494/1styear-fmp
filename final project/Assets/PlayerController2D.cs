using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer SpriteRenderer;

    bool isGrounded;

    [SerializeField]
    Transform groundcheck;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {

        if (Physics2D.Linecast(transform.position, groundcheck, 1 << LayerMask.NameToLayer("ground")))
        {

        }
        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(8, rb2d.velocity.y);
            animator.Play("Player_run");
            SpriteRenderer.flipX = false;
        }

        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-8, rb2d.velocity.y);
            animator.Play("Player_run");
            SpriteRenderer.flipX = true;
        }

        else
        {
            animator.Play("Player_idle");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey("w"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 3);
            animator.Play("Player_jump");
        }
    }
}
