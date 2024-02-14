using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private GameObject loadingPopout;
    [SerializeField] private GameObject noSaveGame;
    public void NewGameYes()
    {
        PlayerPrefs.SetInt("isSaved", 1);
        loadingPopout.GetComponent<loadingPopout>().isSaved = false;
        loadingPopout.GetComponent<loadingPopout>().enabled = true;
    }
    public void LoadGameYes()
    {
        if (PlayerPrefs.GetInt("isSaved") == 1)
        {
            loadingPopout.GetComponent<loadingPopout>().isSaved = true;
            loadingPopout.GetComponent<loadingPopout>().enabled = true;
        }
        else
            noSaveGame.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
