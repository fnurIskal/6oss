using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Animator anim;
    public float maxHealth;
    public float currentHealth;
    public bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.GetComponent<floatingHealthBar>().UpdateHealthBar(currentHealth, maxHealth);
    }
    void Update()
    {
        healthBar.GetComponent<floatingHealthBar>().UpdateHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //anim.SetTrigger("hurt");
        healthBar.GetComponent<floatingHealthBar>().UpdateHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        isDead = true;
        anim.SetTrigger("death");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
