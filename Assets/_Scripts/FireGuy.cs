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
    public float startTimeBtwShots;
    public GameObject bullet;
    private Animator anim;
    public float health;
    public float maxHealth=100f;
    private Rigidbody2D rb;
    private bool isAttacking = false;
    public GameObject bulletSpawnpos;
    public GameObject healthBar;
    public bool isDamaged = false;
    enum MovementState { idle,attack,hurt,death}

    [SerializeField] private AudioSource FireBallSound;
    [SerializeField] private AudioSource DieSound;

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
    

        if (Vector2.Distance(transform.position, Player.position) <= shootingRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }
    private IEnumerator Attack()
    {
        MovementState state;
        if (!isAttacking)
        {
            isAttacking = true;
            state = MovementState.attack;
            anim.SetInteger("state", (int)state);
            FireBallSound.Play();
            yield return new WaitForSeconds(3f);
            isAttacking = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, shootingRange);
       
        Gizmos.DrawWireSphere(transform.position, retreatDistance);
       
    }
    public void SpawnFireball()
    {
        Instantiate(bullet, bulletSpawnpos.transform.position, Quaternion.identity);
    }
    public void EnemyTakeDamage(float amount)
    {
        if (!isDamaged)
        {
            health -= amount;
            healthBar.GetComponent<floatingHealthBar>().UpdateHealthBar(health, maxHealth);
            if (health <= 0)
            {
                die();
            }
            else
            {
                anim.SetTrigger("hurt");
            }
        }
    }
    public void WaitForDamage()
    {
        isDamaged = !isDamaged;
    }
    void die()
    {
        
        anim.SetTrigger("death");
        rb.isKinematic = false;
     }

    public void DeathSound()
    {
        DieSound.Play();
    }

    void destroyobject()
    {
        Destroy(gameObject);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  


}
//Vector2.Distance(transform.position, Player.position) <= shootingRange)
        

    

    

    