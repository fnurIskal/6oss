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

  
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject bullet;
    

    private Transform player;
    private Animator anim;
    enum MovementState { walking, hurt, death, attack}
    [SerializeField] private AudioSource GumDeathSound;
    [SerializeField] private AudioSource GumAttackSound;

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
      
        //rb.isKinematic = true;
    }

    public void DeathSound()
    {
        GumDeathSound.Play();
    }

    void Update()
    {
        Movement();
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
        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);

         if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {

            
            state = MovementState.walking;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            anim.SetInteger("state", (int)state);

        } 
        if (timeBtwShots <= 0 && distanceFromPlayer <= shootingRange)
        {
            
            state = MovementState.attack;

            
   anim.SetInteger("state", (int)state);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }


    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        GumAttackSound.Play();
    }
    void Die()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(float damageAmount)
    {
        anim.SetTrigger("hurt");
        health -=damageAmount;
        healthBar.UpdateHealthBar(health,maxHealth);
        
        if(health <= 0)
        {
            anim.SetTrigger("death");

        }
        
    }





}
