using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Transform Player;
    private Vector2 target;

    public int damage;
   

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(Player.position.x, Player.position.y);
        if (Player != null)  // Player null deðilse target'i güncelle
        {
            UpdateTarget();
        }
        else
        {
            // Eðer Player null ise, bir hata mesajý yazabilir veya baþka bir iþlem yapabilirsiniz
            Debug.LogError("Player not found!");
        }
      
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Player != null)  // Player null deðilse hareket etmeye devam et
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyBullet();
            }
        }
   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            DestroyBullet();
        }
       
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    void UpdateTarget()
    {
        target = new Vector2(Player.position.x, Player.position.y);
    }
  
   
}
