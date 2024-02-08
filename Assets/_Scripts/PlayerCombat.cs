using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject fireSpawn;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackRange;
    [SerializeField] private robotShooting damaged;
    private bool canAttack = true;
    private bool canFire = true;
    private bool canWater = true;
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
                    if (hit.CompareTag("snowman"))
                        hit.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                    else if (hit.CompareTag("robot"))
                        damaged.takeDamaged(attackDamage);
                    //sakýzguy da ekle kýnýk
                }
            }
            yield return new WaitForSeconds(attackCoolDown);
            canAttack = true;
        }
    }
    IEnumerator Fire()
    {
        if (canFire)
        {
            rb.bodyType = RigidbodyType2D.Static;
            canFire = false;
            anim.SetTrigger("fire");
            yield return new WaitForSeconds(0.9f);

            Instantiate(fire, fireSpawn.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.6f);
            canFire = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    IEnumerator Water()
    {
        if (canWater)
        {
            rb.bodyType = RigidbodyType2D.Static;
            canWater = false;
            anim.SetTrigger("water");
            yield return new WaitForSeconds(0.7f);
            
            Instantiate(fire, fireSpawn.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);//düzelt 0.4789
            canWater = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
