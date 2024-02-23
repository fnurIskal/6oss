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
    private bool isAttacking = false;

    [SerializeField] private AudioSource FireBallSound;
    [SerializeField] private AudioSource WaterBallSound;
    [SerializeField] private AudioSource SwordSwingSound;
    [SerializeField] private AudioSource SwordSwingGolemSound;
    [SerializeField] private AudioSource SwordSwingSnowmanSound;
    [SerializeField] private AudioSource SwordSwingRobotSound;
    [SerializeField] private AudioSource SwordSwingFireguySound;
    [SerializeField] private AudioSource SwordSwingSak�zguySound;

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
        if (canAttack)
        {
            canAttack = false;
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
                        SwordSwingSak�zguySound.Play();
                        hit.GetComponent<GumMonsterMovement>().TakeDamage(attackDamage);
                    }
                   
                }
            }
            yield return new WaitForSeconds(attackCoolDown);
            canAttack = true;
        }
    }
    IEnumerator Fire()
    {
        if (canFire && !isAttacking)
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
        if (canWater && !isAttacking)
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
