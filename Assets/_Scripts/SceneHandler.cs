using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private GameObject loadingPopout;
    [SerializeField] private GameObject noSaveGame;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject healthbar;
    [SerializeField] private GameObject img;
    [SerializeField] private Slider volumeSlider;
    public void NewGameYes()
    {
        PlayerPrefs.SetInt("isSaved", 1);
        PlayerPrefs.SetInt("level", 1);
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
    public void PauseMenu(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<Animator>().enabled = false;
            healthbar.SetActive(false);
            img.SetActive(false);
            pauseMenu.SetActive(true);
        }
        else
        {
            healthbar.SetActive(true);
            img.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
            GameObject.FindWithTag("Player").GetComponent<Animator>().enabled = true;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RetryMenu()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
    public void SetVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
