using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackRange;
    [SerializeField] private robotShooting damaged;
    private bool canAttack = true;
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canAttack)
        {
            StartCoroutine(Attack());
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
                    if (hit.CompareTag("snowman"))
                        hit.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                    else if (hit.CompareTag("robot"))
                        damaged.takeDamaged(attackDamage);

                }
            }
            yield return new WaitForSeconds(attackCoolDown);
            canAttack = true;
        }
    }
}
