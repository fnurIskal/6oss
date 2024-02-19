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
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = 100f;
    }
    private void Die()
    {
        if(currentHealth == 0)
        {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        golem.isTakedDamage = true;
        healthBar.GetComponent<floatingHealthBar>().UpdateHealthBar(currentHealth, 100f);
    }
}
