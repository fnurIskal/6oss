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
        }
    }

    public void OnWater(InputAction.CallbackContext context)
    {
        if (context.performed && canWater)
        {
            StartCoroutine(Water());
        }
    }

    IEnumerator Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            anim.SetTrigger("attack");
            yield return new WaitForSeconds(0.7f);

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);
            foreach(Collider2D hit in hitEnemies)
            {
                if (Vector2.Distance(hit.transform.position, transform.position) < attackRange)
                {
                    if (hit.CompareTag("Snowman"))
                        hit.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                    else if (hit.CompareTag("Robot"))
                        hit.GetComponent<robotShooting>().takeDamaged(attackDamage);
                    else if (hit.CompareTag("Box"))
                        hit.GetComponent<BrokenBox>().StartBreaking();
                    else if (hit.CompareTag("Fireguy"))
                        hit.GetComponent<FireGuy>().EnemyTakeDamage(attackDamage);
                    else if (hit.CompareTag("Golem"))
                        hit.GetComponent<GolemHealth>().TakeDamage(attackDamage);
                    else if (hit.CompareTag("Sak�zguy"))
                        hit.GetComponent<GumMonsterMovement>().TakeDamage(attackDamage);
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
            yield return new WaitForSeconds(0.9f);

            Instantiate(fire, bulletSpawn.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(0.6f);
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
            yield return new WaitForSeconds(0.7f);

            Instantiate(water, bulletSpawn.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(0.4789f);
            canWater = true;
            isAttacking = false;
        }
    }
}
