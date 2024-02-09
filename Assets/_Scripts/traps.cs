using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traps : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bigTrap"))
        {
            gameObject.GetComponent<PlayerHealth>().Die();
        }
        else if (collision.CompareTag("smallTrap"))
        {
            gameObject.GetComponent<PlayerHealth>().TakeDamage(10); // rastgele deger verdim
        }
    }
}