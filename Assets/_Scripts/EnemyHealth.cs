using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Animator anim;
    public float maxHealth;
    public float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.GetComponent<floatingHealthBar>().UpdateHealthBar(currentHealth, maxHealth);
    }
    void Update()
    {
        healthBar.GetComponent<floatingHealthBar>().UpdateHealthBar(currentHealth, maxHealth);
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //anim.SetTrigger("hurt");
        healthBar.GetComponent<floatingHealthBar>().UpdateHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Öldük.");
            Die();
        }
    }
    public void Die()
    {
        anim.SetTrigger("death");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
