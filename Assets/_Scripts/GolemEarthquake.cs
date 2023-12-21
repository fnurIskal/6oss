using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEarthquake : MonoBehaviour
{
    private GameObject Player;
    private Animator anim;
    private PolygonCollider2D earthCollider;
    public float earthquakeDamage;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        earthCollider = GetComponent<PolygonCollider2D>();
        earthCollider.enabled = false;
    }
    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8)
        {
            earthCollider.enabled = true;
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<healthManager>().TakeDamage(earthquakeDamage);
        }
    }
}
