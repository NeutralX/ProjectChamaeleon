using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Range(2f, 20f)]
    public float speed = 2f;
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public GameObject game;
    public Slider healthslider;
    private AudioSource audioPlayer;
    public AudioClip die;
    public AudioClip pickItem;
    public AudioClip heal;

    private float VelX, VelY;
    public Boolean up, down, left, right;
    
    public int health = 10;


    // Start is called before the first frame update
    void Start()
    {
        healthslider.maxValue = health;
        healthslider.value = health;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        audioPlayer = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        //TODO: Esperar a que la animacio d'atacar acabi. Mentres ataca, true boolean i esperar el trigger de colisio de l'enemic. Si no, false boolean.
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
        rb2d.velocity = new Vector2(VelX * speed, VelY * speed);
    }

    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        audioPlayer.clip = pickItem;
        audioPlayer.Play();
        if (other.gameObject.CompareTag("Stairs"))
        {
            game.GetComponent<GameController>().SendMessage("ChangeFloor");
            
        } else if (other.gameObject.CompareTag("Food"))
        {
            other.gameObject.SetActive(false);
            healthHeal(4);
        }
    }
    
    public void healthLost(int damage)
    {
        health -= damage;
        healthslider.value = health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void healthHeal(int heal)
    {
        audioPlayer.clip = this.heal;
        audioPlayer.Play();
        if (health + heal > 10)
        {
            health = 10;
            
        }
        else
        {
            health += heal;
        }
        
        healthslider.value = health; 
    }




}
