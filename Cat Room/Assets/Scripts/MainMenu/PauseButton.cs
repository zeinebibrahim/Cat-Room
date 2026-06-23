using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas; 
    private bool isPaused = false;

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;        
        pauseCanvas.SetActive(true);  
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;        
        pauseCanvas.SetActive(false);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
