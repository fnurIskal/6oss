using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FireGuy : MonoBehaviour
{
    public float speed;
    public float retreatDistance;
    public float shootingRange;
    public Transform Player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject bullet;
    private Animator anim;
    public float health;
    public float maxHealth=10f;
    private Rigidbody2D rb;
    private bool isPlayerAttacking = false;
   
   
    enum MovementState { idle,attack,hurt,death}
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        health = maxHealth;
        rb= GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        MovementState state;

        // Oyuncunun saldýrý durumu kontrol ediliyor
        if (isPlayerAttacking)
        {
            // Düþmanýn hasar almasý
            EnemyTakeDamage(1); // Hasar miktarý burada 1 olarak varsayýlmýþtýr, deðiþtirebilirsiniz
        }

        if (Player.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        if (Vector2.Distance(transform.position,Player.position) < retreatDistance)
        {
            float step = -speed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(Player.position.x, transform.position.y), step);
            transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
            state = MovementState.idle;
            anim.SetInteger("state", (int)state);

            

        }
        else if (Vector2.Distance(transform.position, Player.position) > shootingRange)
        {
            state = MovementState.idle;
            anim.SetInteger("state", (int)state);
        }
    

        if (Vector2.Distance(transform.position, Player.position) <= shootingRange && timeBtwShots <= 0)
        {
            state = MovementState.attack;
            anim.SetInteger("state", (int)state);
            
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots-=Time.deltaTime;
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, shootingRange);
       
        Gizmos.DrawWireSphere(transform.position, retreatDistance);
       
    }
    public void SpawnFireball()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    public void EnemyTakeDamage(int amount)
    {
        Debug.Log("!");
        health -= amount;
        if(health<=0)
        {
            die();
        }
        else
        {
            anim.SetTrigger("hurt");
        }
    }

    void die()
    {
        anim.SetTrigger("death");
        rb.isKinematic = false;
        Invoke("RestartGame", 1f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  


}
//Vector2.Distance(transform.position, Player.position) <= shootingRange)
        

    

    

    