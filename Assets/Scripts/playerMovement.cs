using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    [Header("Velocidades")]
    public float runSpeed;
    public float jumpForce;


    public bool isMove = false;
    public bool isLeft = false;
    public bool isRight = false;

    Rigidbody2D rb2d;
    Animator animator;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void moveRight()
    {
        isRight = true;
        isLeft = false;
        isMove = true;
    }

    public void moveLeft()
    {
        isRight = false;
        isLeft = true;
        isMove = true;

    }

    public void dontMove()
    {
        isMove = false;
        isRight = false;
        isLeft = false;
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            if (isLeft)
            {
                rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                animator.SetTrigger("Run");
            }

            else if (isRight)
            {
                rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
                transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                animator.SetTrigger("Run");
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetTrigger("Idle");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
