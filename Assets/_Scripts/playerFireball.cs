using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFireball : MonoBehaviour
{
    private float force = 5f;
    private float timer;
    void Start()
    {
        transform.Translate(Vector3.forward * force * Time.deltaTime); // olmadý 
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag(""))
    //    {
    //        Destroy(gameObject);
    //        other.GetComponent<PlayerHealth>().TakeDamage(bulletDamage);
    //    }
    //}
}
