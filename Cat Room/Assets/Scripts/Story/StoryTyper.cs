using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryTyper : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public float typeSpeed = 0.03f;
    public float delayBetweenSentences = 2.5f;
    public string[] introSentences;
    public bool playIntroOnStart = true;


    private Coroutine typingRoutine;

    void Start()
    {
        if (playIntroOnStart)
            PlayStory(introSentences);
    }


    public void PlayStory(string[] sentences, bool switchSceneAfter = false, string sceneName = "")
    {
        if (typingRoutine != null)
            StopCoroutine(typingRoutine);

        typingRoutine = StartCoroutine(TypeSentences(sentences, switchSceneAfter, sceneName));
    }

    private IEnumerator TypeSentences(string[] sentences, bool switchSceneAfter, string sceneName)
    {
        storyText.text = "";

        foreach (string sentence in sentences)
        {
            storyText.text = "";

            foreach (char c in sentence)
            {
                storyText.text += c;
                yield return new WaitForSeconds(typeSpeed);
            }

            yield return new WaitForSeconds(delayBetweenSentences);
        }

        if (switchSceneAfter)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(sceneName);
        }
    }
}
