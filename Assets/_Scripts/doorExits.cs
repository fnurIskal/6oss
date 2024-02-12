using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorExits : MonoBehaviour
{
    private string currentSceneName;
    private PlayerHealth playerHealth;
    private EnemyHealth snowmanHealth;
    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        snowmanHealth = GameObject.FindWithTag("Snowman").GetComponent<EnemyHealth>();
    }
    private void Update()
    {
        if (!snowmanHealth.isDead)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        if (collision.CompareTag("Player"))
        {
            switch (currentSceneName)
            {
                case "memo":
                    Thread.Sleep(500);
                    SceneManager.LoadScene("emran");

                    break;

                case "emran":
                    Thread.Sleep(500);
                    SceneManager.LoadScene("begum");

                    break;

                case "begum":
                    if (playerHealth.hasKey)
                    {
                        Thread.Sleep(500);
                        SceneManager.LoadScene("ýsgal");
                    }

                    break;

                case "ýsgal":
                    Thread.Sleep(500);
                    SceneManager.LoadScene("umud");

                    break;

                default:
                    Debug.Log("hata");
                    break;
            }
        }
    }
}