using System.Collections;
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
                    StartCoroutine(caseMemo());
                    break;

                case "emran":
                    StartCoroutine(caseEmrean());
                    break;

                case "begum":
                    if (playerHealth.hasKey)
                        StartCoroutine(caseBegum());
                    break;

                case "ýsgal":
                    StartCoroutine(caseIsgal());
                    break;

                case "heca":
                    StartCoroutine(caseHeca());
                    break;
                default: break;
            }
        }
    }
    private IEnumerator caseMemo()
    {
        yield return new WaitForSeconds(2f); 
        PlayerPrefs.SetInt("level", 2);
        SceneManager.LoadScene("emran");
    }
    private IEnumerator caseEmrean()
    {
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("level", 3);
        SceneManager.LoadScene("begum");
    }
    private IEnumerator caseBegum()
    {
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("level", 4);
        SceneManager.LoadScene("ýsgal");
    }
    private IEnumerator caseIsgal()
    {
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("level", 5);
        SceneManager.LoadScene("heca");
    }
    private IEnumerator caseHeca()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("WinScene");
    }
}