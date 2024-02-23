using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackRange;
    private bool canAttack = true;
    private bool canFire = true;
    private bool canWater = true;
    public bool isAttacking = false;
    public bool isSword = false;

    [SerializeField] private AudioSource FireBallSound;
    [SerializeField] private AudioSource WaterBallSound;
    [SerializeField] private AudioSource SwordSwingSound;
    [SerializeField] private AudioSource SwordSwingGolemSound;
    [SerializeField] private AudioSource SwordSwingSnowmanSound;
    [SerializeField] private AudioSource SwordSwingRobotSound;
    [SerializeField] private AudioSource SwordSwingFireguySound;
    [SerializeField] private AudioSource SwordSwingSakýzguySound;

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canAttack)
        {
            StartCoroutine(Attack());
            
        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && canFire)
        {
            StartCoroutine(Fire());
            FireBallSound.Play();
        }
    }

    public void OnWater(InputAction.CallbackContext context)
    {
        if (context.performed && canWater)
        {
            StartCoroutine(Water());
            WaterBallSound.Play();
        }
    }

    public void Sword()
    {
        SwordSwingSound.Play();
    }

    IEnumerator Attack()
    {
        if (canAttack && !isAttacking && !gameObject.GetComponent<PlayerMovement>().isDashing)
        {
            canAttack = false;
            isSword = true;
            anim.SetTrigger("attack");
            yield return new WaitForSeconds(1f);

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);
            foreach(Collider2D hit in hitEnemies)
            {
                if (Vector2.Distance(hit.transform.position, transform.position) < attackRange)
                {
                    if (hit.CompareTag("Snowman"))
                    {
                        SwordSwingSnowmanSound.Play();
                        hit.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                    }
                    else if (hit.CompareTag("Robot"))
                    {
                        SwordSwingRobotSound.Play();
                        hit.GetComponent<robotShooting>().takeDamaged(attackDamage);
                    }
                    else if (hit.CompareTag("Box"))
                        hit.GetComponent<BrokenBox>().StartBreaking();
                    else if (hit.CompareTag("Fireguy"))
                    {
                        SwordSwingFireguySound.Play();
                        hit.GetComponent<FireGuy>().EnemyTakeDamage(attackDamage);
                    }
                    else if (hit.CompareTag("Golem"))
                    {
                        SwordSwingGolemSound.Play();
                        hit.GetComponent<GolemHealth>().TakeDamage(attackDamage);
                    }
                    else if (hit.CompareTag("Sakizguy"))
                    {
                        SwordSwingSakýzguySound.Play();
                        hit.GetComponent<GumMonsterMovement>().TakeDamage(attackDamage);
                    }
                   
                }
            }
            yield return new WaitForSeconds(attackCoolDown);
            isSword = false;
            canAttack = true;
        }
    }
    IEnumerator Fire()
    {
        if (canFire && !isAttacking && !gameObject.GetComponent<PlayerMovement>().isDashing)
        {
            canFire = false;
            isAttacking = true;
            anim.SetTrigger("fire");
            yield return new WaitForSeconds(1f);

            Instantiate(fire, bulletSpawn.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(2.2f);
            canFire = true;
            isAttacking = false;
        }
    }

    IEnumerator Water()
    {
        if (canWater && !isAttacking && !gameObject.GetComponent<PlayerMovement>().isDashing)
        {
            canWater = false;
            isAttacking = true;
            anim.SetTrigger("water");
            yield return new WaitForSeconds(1f);

            Instantiate(water, bulletSpawn.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(2f);
            canWater = true;
            isAttacking = false;
        }
    }
}
