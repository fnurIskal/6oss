using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrokenBox : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr=GetComponent <SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.gameObject.GetComponent<PlayerMovement>())
           StartCoroutine( Break());

    }

    private IEnumerator Break()
    {
        particle.Play();
        sr.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
