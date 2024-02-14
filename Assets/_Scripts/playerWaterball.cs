using UnityEngine;

public class playerWaterball : MonoBehaviour
{
    private float force = 5f;
    private float lifeTime = 3f;
    private PlayerMovement playerMovement;
    private bool isFacingRight;
    public SpriteRenderer spriteRenderer;
    private void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        isFacingRight = playerMovement.isFacingRight;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (isFacingRight)
        {
            transform.Translate(new Vector3(force * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = false;
        }
        else
        {
            transform.Translate(new Vector3(-force * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fireguy"))
        {
            Destroy(gameObject);
            other.GetComponent<FireGuy>().EnemyTakeDamage(15);
        }
    }
}
