using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    public void ReplayFightButton()
    {
        SceneManager.LoadScene("StreetFight");
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
