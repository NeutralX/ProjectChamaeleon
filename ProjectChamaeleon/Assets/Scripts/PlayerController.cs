using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(2f, 20f)]
    public float speed = 2f;
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private float VelX, VelY;
    private Boolean up, down, left, right;

    public Transform  attackPosLeft;
    public Transform  attackPosRight;
    public Transform  attackPosUp;
    public Transform  attackPosDown;
    public LayerMask whatIsEnemies;
    public float attackRange;

    public int health;


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
        spriteRenderer.flipX = false;
        //TODO: Esperar a que la animacio d'atacar acabi. Mentres ataca, true boolean i esperar el trigger de colisio de l'enemic. Si no, false boolean.
        VelX = Input.GetAxisRaw("Horizontal");
        VelY = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Fire1"))
        {
            if (left)
            {
                UpdateState("PlayerAttackLeft");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosLeft.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(1);
                }
            } else if (right)
            {
                spriteRenderer.flipX = true;
                UpdateState("PlayerAttackRight");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosRight.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(1);
                }
            }else if (up)
            {
                UpdateState("PlayerAttackUp");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosUp.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(1);
                }
            }else if (down)
            {
                UpdateState("PlayerAttackDown");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosDown.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(1);
                }
            }
            
            

        }
        else if (VelX != 0 || (VelY != 0 && VelX != 0) || (VelY != 0 && VelX == 0))
        {
            //spriteRenderer.flipX = false;
            if (VelX < 0)
            {
                UpdateState("PlayerMovementLeft");
                left = true;
                up = false;
                down = false;
                right = false;
            }
            else if (VelX > 0)
            {
                spriteRenderer.flipX = true;
                UpdateState("PlayerMovementLeft");
                right = true;
                up = false;
                down = false;
                left = false;
            }
            else if(VelY > 0)
            {
                UpdateState("PlayerMovementUp");
                up = true;
                down = false;
                left = false;
                right = false;
            }
            else if(VelY < 0)
            {
                UpdateState("PlayerMovementDown");
                down = true;
                up = false;
                left = false;
                right = false;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            up = true;
                down = false;
                left = false;
                right = false;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            down = true;
                up = false;
                left = false;
                right = false;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            left = true;
                up = false;
                down = false;
                right = false;
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
                up = false;
                down = false;
                left = false;
        }

        else if (!Input.anyKey)
        {
            //spriteRenderer.flipX = false;
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
        rb2d.velocity = new Vector2(VelX * speed, VelY * speed);
    }

    void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosLeft.position, attackRange);
        Gizmos.DrawWireSphere(attackPosRight.position, attackRange);
        Gizmos.DrawWireSphere(attackPosUp.position, attackRange);
        Gizmos.DrawWireSphere(attackPosDown.position, attackRange);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.gameObject.CompareTag("Stairs"))
        {
            
            game.GetComponent<GameController>().gameState = GameState.Ended;
            enemyGenerator.SendMessage("CancelGenerator",true);
            game.SendMessage("ResetTimeScale", 0.5f);
            
            game.GetComponent<AudioSource>().Stop();
            audioPlayer.clip = dieClip;
            audioPlayer.Play();
            
            DustStop();
        } else if (other.gameObject.CompareTag("Point"))
        {
            game.SendMessage("IncreasePoints");
        }*/
    }




}
