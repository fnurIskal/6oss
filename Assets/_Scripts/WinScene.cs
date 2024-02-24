using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScene : MonoBehaviour
{
   public void LastGameMenu()
    {
        PlayerPrefs.SetInt("isSaved", 1);
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene("memo");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
   
}
