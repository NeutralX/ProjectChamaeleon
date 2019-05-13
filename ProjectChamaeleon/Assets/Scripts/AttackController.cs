using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    
    private float timeBtwAttacks;
    public float startTimeBtwAttack;

    private PlayerController playerController;

    private SpriteRenderer spriteRenderer;
    
    public Transform  attackPosLeft;
    public Transform  attackPosRight;
    public Transform  attackPosUp;
    public Transform  attackPosDown;
    public LayerMask whatIsEnemies;
    public float attackRange;
    private AudioSource audioPlayer;
    public AudioClip attack;
    
    // Start is called before the first frame update
    void Start()
    {
    playerController = gameObject.GetComponent<PlayerController>();
    spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttacks <= 0 && Input.GetKey(KeyCode.Mouse0))
        {
            //spriteRenderer.flipX = false;
            if (playerController.left)
            {
                playerController.UpdateState("PlayerAttackLeft");
                audioPlayer.clip = attack;
                audioPlayer.Play();
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosLeft.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(1);
                }
            } else if (playerController.right)
            {
                spriteRenderer.flipX = true;
                playerController.UpdateState("PlayerAttackRight");
                audioPlayer.clip = attack;
                audioPlayer.Play();
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosRight.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(1);
                }
            }else if (playerController.up)
            {
                playerController.UpdateState("PlayerAttackUp");
                audioPlayer.clip = attack;
                audioPlayer.Play();
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosUp.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(1);
                }
            }else if (playerController.down)
            {
                playerController.UpdateState("PlayerAttackDown");
                audioPlayer.clip = attack;
                audioPlayer.Play();
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosDown.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(1);
                }
            }

            timeBtwAttacks = startTimeBtwAttack;
            
        }
        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }
        
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosLeft.position, attackRange);
        Gizmos.DrawWireSphere(attackPosRight.position, attackRange);
        Gizmos.DrawWireSphere(attackPosUp.position, attackRange);
        Gizmos.DrawWireSphere(attackPosDown.position, attackRange);
    }
    
}
