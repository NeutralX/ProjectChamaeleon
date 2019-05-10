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
    private Animation animation;
    
    private float timeBtwAttacks;
    public float startTimeBtwAttack;
    
    public Transform  attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

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
            //spriteRenderer.flipX = false;
            transform.localScale = new Vector2(1,1);
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
                //spriteRenderer.flipX = true;
                transform.localScale = new Vector2(-1,1);
                UpdateState("EnemyMovementLeft");
            }
            
            

        }

        if (Vector2.Distance(transform.position, target.position) > 1 && Vector2.Distance(transform.position, target.position) < 6)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        if (Vector2.Distance(transform.position, target.position) <= 3 && timeBtwAttacks <= 0)
        {
            UpdateState("EnemyAttackLeft");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<PlayerController>().healthLost(1);
            }
                
            timeBtwAttacks = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }

        

        
    }

    void UpdateState(string state = null)
        {
            if (state != null)
            {
                animator.Play(state);
                animation  = animator.GetComponent<Animation>();
                WaitForAnimation( animation );
            }
        }
    
    private IEnumerator WaitForAnimation ( Animation animation )
    {
        do
        {
            yield return null;
        } while ( animation.isPlaying );
    }

    public void TakeDamage(int damage){
        health -= damage;
           
    }
    
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
