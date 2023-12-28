using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public Animator anim;
    public float healthAmount = 100f;
    private bool isDeath = false;

    void Update()
    {
        if (healthAmount <= 0 && !isDeath)
        {
            isDeath = true;
            anim.SetTrigger("Death");
        }
    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.value = healthAmount / 100f;
        anim.SetTrigger("Damage");
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.value = healthAmount / 100f;
    }
}
