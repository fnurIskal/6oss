using UnityEngine;

public class SnowmanAI : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;
    public GameObject snowball;
    public Transform[] snowballPos;
    private int condition;
    private float timer;
    private GameObject player;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private float attackInterval;
    [SerializeField] private float detectRange;
    [SerializeField] private AudioSource SnowBallSound;
    [SerializeField] private AudioSource SnowManDeathSound;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyHealth.currentHealth = enemyHealth.maxHealth;
    }
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        if (enemyHealth.currentHealth > 17 && enemyHealth.currentHealth <= 20)
        {
            condition = 1;
            anim.SetInteger("condition", condition);
        }
        else if (enemyHealth.currentHealth > 14 && enemyHealth.currentHealth <= 17)
        {
            condition = 2;
            anim.SetInteger("condition", condition);
        }
        else if (enemyHealth.currentHealth > 11 && enemyHealth.currentHealth <= 14)
        {
            condition = 3;
            anim.SetInteger("condition", condition);
        }
        else if (enemyHealth.currentHealth > 8 && enemyHealth.currentHealth <= 11)
        {
            condition = 4;
            anim.SetInteger("condition", condition);
        }
        else if (enemyHealth.currentHealth > 4 && enemyHealth.currentHealth <= 8)
        {
            condition = 5;
            anim.SetInteger("condition", condition);
        }
        else if (enemyHealth.currentHealth > 0 && enemyHealth.currentHealth <= 4)
        {
            condition = 6;
            anim.SetInteger("condition", condition);
        }
        else if (enemyHealth.currentHealth <= 0)
        {
            condition = 7;
            anim.SetInteger("condition", condition);
            enemyHealth.Die();
        }
        if (Vector2.Distance(transform.position, player.transform.position) < detectRange)
        {
            Attack();
            anim.SetBool("isAttacking", true);
        }
        else
            anim.SetBool("isAttacking", false);
    }
    public void DeathSound()
    {
        SnowManDeathSound.Play();
    }
    void Attack()
    {
       
        timer += Time.deltaTime;
        if (timer > attackInterval)
        {
            timer = 0;
        }
    }
    public void ThrowSnowball()
    {
        SnowBallSound.Play();
        if (sprite.flipX)
            Instantiate(snowball, snowballPos[0].position, Quaternion.identity);
        else
            Instantiate(snowball, snowballPos[1].position, Quaternion.identity);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}