using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void NewGameYes()
    {
        SceneManager.LoadScene("memo");
    }
    public void LoadGameYes()
    {
        // saveden hangi sahnede oldugunu al, yükle 
    }
}
