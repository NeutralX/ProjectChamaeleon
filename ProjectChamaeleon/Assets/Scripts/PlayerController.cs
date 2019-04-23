using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(5f, 20f)]
    public float speed = 5f;
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private string lastKeyMovement;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        bool userActionW = Input.GetKeyDown("w");
        bool userActionA = Input.GetKeyDown("a");
        bool userActionS = Input.GetKeyDown("s");
        bool userActionD = Input.GetKeyDown("d");

        if (userActionW || userActionA || userActionS || userActionD)
        {
            spriteRenderer.flipX = false;
            if (userActionA)
            {
                lastKeyMovement = "A";
                UpdateState("PlayerIdleLeft");
            }
            if (userActionD)
            {
                lastKeyMovement = "D";
                spriteRenderer.flipX = true;
                UpdateState("PlayerIdleLeft");
            }
            if (userActionW)
            {
                lastKeyMovement = "W";
                //UpdateState("PlayerIdleUp");
            }
            if (userActionS)
            {
                lastKeyMovement = "S";
                UpdateState("PlayerIdleDown");
            }

            

        }
        else if (!Input.anyKey)
        {
            UpdateState("PlayerIdleDown");
        }
    }


    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }


    void LastUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        bool spacePressed = Input.GetKeyDown("space");

        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);

        rb2d.velocity = movement;


    }
}
