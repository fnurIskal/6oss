using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public Animator anim;
    public Rigidbody2D rb;
    public float healthAmount = 100f;
    private bool isDeath = false;
    public bool hasKey = false;

    void Update()
    {
        if (healthAmount <= 0 && !isDeath)
        {
            isDeath = true;
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        if (!gameObject.GetComponent<PlayerMovement>().isDashing)
        {
            anim.SetTrigger("Damage");
            healthAmount -= damage;
            healthBar.value = healthAmount / 100f;
        }
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.value = healthAmount / 100f;
    }
    public void Die()
    {
        healthAmount = 0;
        healthBar.value = healthAmount / 100f;
        gameObject.GetComponent<PlayerInput>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Meat"))
        {
            Heal(30f);
            Destroy(collision.gameObject);
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("DeadScene");
    }
}
