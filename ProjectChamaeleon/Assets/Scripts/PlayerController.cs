using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(5f, 20f)]
    public float speed = 2f;
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private float VelX, VelY;
    private Boolean up, down, left, right;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        VelX = Input.GetAxisRaw("Horizontal");
        VelY = Input.GetAxisRaw("Vertical");
        if (VelX != 0 || (VelY != 0 && VelX != 0) || (VelY != 0 && VelX == 0))
        {
            spriteRenderer.flipX = false;
            if (VelX < 0)
            {
                UpdateState("PlayerMovementLeft");
                left = true;
                up = false;
                down = false;
                right = false;
            }
            if (VelX > 0)
            {
                spriteRenderer.flipX = true;
                UpdateState("PlayerMovementLeft");
                right = true;
                up = false;
                down = false;
                left = false;
            }
            if (VelY > 0)
            {
                UpdateState("PlayerMovementUp");
                up = true;
                down = false;
                left = false;
                right = false;
            }
            if (VelY < 0)
            {
                UpdateState("PlayerMovementDown");
                down = true;
                up = false;
                left = false;
                right = false;
            }


        }
        else if (!Input.anyKey)
        {
            spriteRenderer.flipX = false;
            if (left)
            {
                UpdateState("PlayerIdleLeft");
            }
            else if (right)
            {
                spriteRenderer.flipX = true;
                UpdateState("PlayerIdleLeft");
            }
            else if (up)
            {
                UpdateState("PlayerIdleUp");
            }
            else if (down)
            {
                UpdateState("PlayerIdleDown");
            }
        }
    }

    private void LateUpdate()
    {
        rb2d.velocity = new Vector2(VelX * 2, VelY * 2);
    }

    void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }


}
