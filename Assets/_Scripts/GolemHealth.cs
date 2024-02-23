using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GolemHealth : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public float currentHealth = 100f;
    public float damage = 5;
    public Golem golem;
    public GameObject healthBar;
    private bool isDead = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = 100f;
    }
    private void Update()
    {
        if (currentHealth <= 0 && !isDead)
            Die();
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        isDead = true;
    }
    public void TakeDamage(float damage)
    {
        if(!gameObject.GetComponent<Golem>().isTeleporting)
        {
            currentHealth -= damage;
            golem.isTakedDamage = true;
            healthBar.GetComponent<floatingHealthBar>().UpdateHealthBar(currentHealth, 100f);
        }
    }
}
