using UnityEngine;

public class BrokenBox : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private bool isBreaking = false;
    private float breakStartTime;
    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (!isBreaking)
        {
            float elapsedTime = Time.deltaTime - breakStartTime;
            if (elapsedTime >= particle.main.startLifetime.constantMax)
            {
                Destroy(gameObject);
            }
        }
    }
    public void StartBreaking()
    {
        particle.Play();
        sr.enabled = false;
        isBreaking = true;
        breakStartTime = Time.deltaTime;
    }
}
