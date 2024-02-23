using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;



public class GumMonsterMovement : MonoBehaviour
{
    public float speed;
    public float retreatDistance;
    public float shootingRange;
    public float lineOfSite;

    [SerializeField] float health, maxHealth = 8f;
    [SerializeField] floatingHealthBar healthBar;

    private Rigidbody2D rb;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject bullet;
    

    private Transform player;
    private Animator anim;
    private bool isFacingRight = true;
    enum MovementState { walking, hurt, death, attack}

    private void Awake()
    {
        healthBar = GetComponentInChildren<floatingHealthBar>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        anim = GetComponent<Animator>();
        healthBar.UpdateHealthBar(health, maxHealth);
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }


    void Update()
    {
        Movement();
        if ((transform.position.x > player.position.x) && isFacingRight)
        {
            Flip();
            isFacingRight = false;
        }
        else if ((transform.position.x < player.position.x) && !isFacingRight)
        {
            Flip();
            isFacingRight = true;
        }

        


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.DrawWireSphere(transform.position, retreatDistance);

    }

    void Movement()
    {
        MovementState state;
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
       
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {

            
            state = MovementState.walking;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            anim.SetInteger("state", (int)state);

        }
       
        else if (distanceFromPlayer <= retreatDistance)
        {
           
            state = MovementState.walking;

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            anim.SetInteger("state", (int)state);
        }
        if (timeBtwShots <= 0 && distanceFromPlayer <= shootingRange)
        {
            
            state = MovementState.attack;

            
            timeBtwShots = startTimeBtwShots;
            anim.SetInteger("state", (int)state);

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    void Die()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(float damageAmount)
    {
        MovementState state;
        
        health -=damageAmount;
        state = MovementState.hurt;
        anim.SetInteger("state",(int)state);
        healthBar.UpdateHealthBar(health,maxHealth);
        
        if(health <= 0)
        {
            state = MovementState.death;
            anim.SetInteger("state",(int)state);            
            
        }
        
    }





}
