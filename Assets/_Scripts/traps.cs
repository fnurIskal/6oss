using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bigTrap"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("smallTrap"))
        {
            //can azaltma
        }
    }
}