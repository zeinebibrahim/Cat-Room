using UnityEngine;

public class ClickableCat : MonoBehaviour
{
    public StoryTyper typer;
    public string[] storyLines;
    public bool switchSceneAfter;
    public string sceneToLoad;

    private void OnMouseDown()
    {
        typer.PlayStory(storyLines, switchSceneAfter, sceneToLoad);
    }
}
