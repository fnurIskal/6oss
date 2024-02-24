using UnityEngine;

public class BrokenBox : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private BoxCollider2D boxcollider2D;
    private bool isBreaking = false;
    private float breakStartTime;
    [SerializeField] private AudioSource BreakSound;
    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        boxcollider2D = GetComponent<BoxCollider2D>();
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
        BreakSound.Play();
        particle.Play();
        sr.enabled = false;
        boxcollider2D.enabled = false;
        isBreaking = true;
        breakStartTime = Time.deltaTime;
    }
}
