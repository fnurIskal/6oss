using UnityEngine;

public class playerFireball : MonoBehaviour
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
        //Vector3 startPoint = transform.position;
        //
        //Vector3 direction = Vector3.up;
        //
        //Ray ray = new Ray(startPoint, direction);
        //
        //if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        //{
        //    if (hitInfo.collider.CompareTag("Ground"))
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("Fireguy"))
        {
            Destroy(gameObject);
            other.GetComponent<FireGuy>().EnemyTakeDamage(5);
        }
        else if (other.gameObject.CompareTag("Snowman"))
        {
            Destroy(gameObject);
            other.GetComponent<EnemyHealth>().TakeDamage(15);
        }
        else if (other.gameObject.CompareTag("Robot"))
        {
            Destroy(gameObject);
            other.GetComponent<robotShooting>().takeDamaged(10);
        }
        
        else if (other.gameObject.CompareTag("Golem"))
        {
            Destroy(gameObject);
            other.GetComponent<GolemHealth>().TakeDamage(10);
        }
        else if (other.gameObject.CompareTag("Sakizguy"))
        {
            Destroy(gameObject);
            other.GetComponent<GumMonsterMovement>().TakeDamage(10);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject) ;
        }
    }
}
