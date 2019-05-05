using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(2f, 20f)]
    public float speed = 2f;
    private Transform target;
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    protected Vector2 direction;

    public int health = 5;
    
    private float VelX, VelY;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
        }
        
        direction = (target.transform.position - transform.position).normalized;

        VelX = direction.x;
        //print("X: " + transform.position.x);
        VelY = direction.y;
        //print("Y: " + direction.y);
        if (VelX != 0 || (VelY != 0 && VelX != 0) || (VelY != 0 && VelX == 0))
        {
            spriteRenderer.flipX = false;
            //if (VelY > 0.50 && VelY < 0.60)
            //{
            //    UpdateState("EnemyMovementUp");
            //}
            //else if (VelY < -0.50 && VelY > -0.60)
            //{
            //    UpdateState("EnemyMovementDown");
            //}
             if (VelX < 0)
            {
                UpdateState("EnemyMovementLeft");
            }
            else if (VelX > 0)
            {
                spriteRenderer.flipX = true;
                UpdateState("EnemyMovementLeft");
            }
            
            

        }

        if (Vector2.Distance(transform.position, target.position) > 1 && Vector2.Distance(transform.position, target.position) < 6)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);



            //if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            //{
            //    //Here Call any function U want Like Shoot at here or something
            //}

        }

        

        
    }

    void UpdateState(string state = null)
        {
            if (state != null)
            {
                animator.Play(state);
            }
        }

    public void TakeDamage(int damage){
            health -= damage;
            Debug.Log("damage TAKEN");
        }
}
