using UnityEngine;

public class playerFireball : MonoBehaviour
{
    private float force = 5f;
    private float lifeTime = 3f;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(new Vector3(force * Time.deltaTime, 0, 0));
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
