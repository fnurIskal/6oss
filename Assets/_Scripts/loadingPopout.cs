using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingPopout : MonoBehaviour
{
    private float timer = 0;
    public bool isSaved = false;
    private void Start()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            gameObject.GetComponent<loadingPopout>().enabled = false;
            gameObject.GetComponent<UnityEngine.UI.Image>().enabled = false;
            if (!isSaved)
                SceneManager.LoadScene("memo");
            else 
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
            }
        }
    }
}
