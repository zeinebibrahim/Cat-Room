using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject tutorialCanvas;
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelTwo");
    }

    public void TutorialButton()
    {
        tutorialCanvas.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialCanvas.SetActive(false);
    }
}
