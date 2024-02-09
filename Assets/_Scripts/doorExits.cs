using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorExits : MonoBehaviour
{
    private string currentSceneName;
    private PlayerHealth playerHealth;
    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
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