using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorExits : MonoBehaviour
{
    private string currentSceneName;
    private PlayerHealth playerHealth;
    public EnemyHealth snowmanHealth;
    [SerializeField] private AudioSource DoorSound;
    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "ýsgal")
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        if (collision.CompareTag("Player"))
        {
            DoorSound.Play();

            switch (currentSceneName)
            {
                case "memo":
                    
                    Thread.Sleep(500);
                    PlayerPrefs.SetInt("level", 2);
                    SceneManager.LoadScene("emran");

                    break;

                case "emran":
                    Thread.Sleep(500);
                    PlayerPrefs.SetInt("level", 3);
                    SceneManager.LoadScene("begum");

                    break;

                case "begum":
                    if (playerHealth.hasKey)
                    {
                        Thread.Sleep(500);
                        PlayerPrefs.SetInt("level", 4);
                        SceneManager.LoadScene("ýsgal");
                    }

                    break;

                case "ýsgal":
                    Thread.Sleep(500);
                    PlayerPrefs.SetInt("level", 5);
                    SceneManager.LoadScene("heca");

                    break;

                default:
                    Debug.Log("hata");
                    break;
            }
        }
    }
}