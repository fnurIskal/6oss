using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineFreeLook;

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
    private float difY;
    private bool canDetect = false;
    [SerializeField] private AudioSource RobotDeathSound;
    [SerializeField] private AudioSource RobotAttackSound;


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
        
        newFlip();
        difY = transform.position.y - player.transform.position.y;
        if ((Vector2.Distance(transform.position, player.transform.position) < lineOfSite) && (difY < 5f) && (difY > -5f))
        {
            canDetect = true;
            follow();
        }
        else
           walking();
    }
    void attacking()
    {

        MovementState state;
        timer += Time.deltaTime;

        if (timer > 3)
        {
            AttackSound();
            timer = 0;
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            state = MovementState.shoot;
            anim.SetInteger("state", (int)state);
        }
    }

    void walking()
    {
        MovementState state;
        state = MovementState.idle;
        anim.SetInteger("state", (int)state);
        if (currentPoint == pointA.transform)
        { 
            if(pointA.transform.position.x < transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            transform.position = Vector2.MoveTowards(transform.position, pointA.transform.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, pointA.transform.position) < .2f)
            {
                currentPoint = pointB.transform;
            }
        }
        else if (currentPoint == pointB.transform)
        {
            if (pointB.transform.position.x > transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
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
        if (canDetect)
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
    }
    void follow()
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
            rb.velocity = Vector2.zero;
            attacking();
        }
        else
        {
            state = MovementState.idle;
            anim.SetInteger("state", (int)state);
            transform.position = Vector2.MoveTowards(transform.position, pointA.transform.position, speed * Time.deltaTime);


        }
    }
    public void takeDamaged(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            rb.velocity = Vector2.zero;
            anim.SetTrigger("death");
        }
        else
        {

        anim.SetTrigger("hurt");
        }
        healthBar.UpdateHealthBar(currentHealth, health);

    }
    public void die()
    {
        Destroy(gameObject);
    }
    public void DeathSound()
    {
        RobotDeathSound.Play();
    }
    public void AttackSound()
    {
        RobotAttackSound.Play();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}