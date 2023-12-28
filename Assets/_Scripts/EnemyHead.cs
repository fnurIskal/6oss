using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    private Animator anim;
    public float force;
    public float headDamage;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - rb.transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, - direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0 ,rot );
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
            {
            other.GetComponent<PlayerHealth>().TakeDamage(headDamage);
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Die");
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
