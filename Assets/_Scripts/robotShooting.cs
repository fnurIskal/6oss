using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public Transform bulletPos;
    public Animator anim;
    public float speed;
    public float speedFollow;
    public float shootingRange;
    public float lineOfSite;
    private float timer;
    private GameObject player;

    public floatingHealthBar healthBar;

    public float health;
    public float currentHealth;

    private enum MovementState { idle, shoot, damaged, death }

   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointA.transform;
        healthBar = GetComponentInChildren<floatingHealthBar>();
        currentHealth = health;
    }
    void Update()
    {
        damaged();
        newFlip();   
        if (Vector2.Distance(transform.position, player.transform.position) < lineOfSite)                
            follow();
        else
            walking();
    }
    void attacking()
    {

        MovementState state;
        timer += Time.deltaTime;

        if (timer > 1)
        {
            timer = 0;
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            state = MovementState.shoot;
            anim.SetInteger("state", (int)state);
        }
    }
    void walking()
    {
       
        if(currentPoint == pointA.transform)
        { MovementState state;
            state = MovementState.idle;
            anim.SetInteger("state", (int)state);

            transform.position = Vector2.MoveTowards(transform.position, pointA.transform.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position,pointA.transform.position)< .2f)
            {
                currentPoint = pointB.transform;
            }
        }
        if (currentPoint == pointB.transform)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointB.transform.position) < .2f)
            {
                currentPoint = pointA.transform;
            }
        }

    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void newFlip()
    {

        float a = transform.position.x - player.transform.position.x;
        if (a > 0)
        {
            if (transform.localScale.x > 0)
            {
                flip();
            }
        }

        else
        {
            if (transform.localScale.x < 0)
            {
                flip();
            }
        }
    }
    private void follow()
    {
        MovementState state;
        float distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceFromPlayer > shootingRange)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speedFollow * Time.deltaTime);
        }
        else if (distanceFromPlayer < shootingRange)
        {
            rb.bodyType = RigidbodyType2D.Static;
            attacking();
        }
        else
        {
            state = MovementState.idle;
            anim.SetInteger("state", (int)state);
            transform.position = Vector2.MoveTowards(transform.position, pointA.transform.position, speed * Time.deltaTime);


        }
    }

    private void damaged()
    {
        MovementState state;
        if (currentHealth < health)
        {
            state = MovementState.damaged;
            health = currentHealth;
            anim.SetInteger("state", (int)state);

        }
        if (currentHealth <= 0)
        {
            state = MovementState.death;
            anim.SetInteger("state", (int)state);


        }
    }
    public void takeDamaged(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, health);

    }
    public void die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}