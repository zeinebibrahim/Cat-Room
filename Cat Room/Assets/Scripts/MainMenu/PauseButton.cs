using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas; 

    public void PauseGame()
    {
        Time.timeScale = 0f;        
        pauseCanvas.SetActive(true);  
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;        
        pauseCanvas.SetActive(false);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
