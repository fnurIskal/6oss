using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScene : MonoBehaviour
{
   public void LastGameMenu()
    {
        SceneManager.LoadScene("memo");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
   
}
