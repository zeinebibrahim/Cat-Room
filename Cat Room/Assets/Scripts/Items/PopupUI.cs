using System.Collections;
using TMPro;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    public static PopupUI Instance;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private float fadeTime = 0.25f;

    private void Awake()
    {
        Instance = this;
        canvasGroup.alpha = 0;
    }

    public void ShowPopup(string text)
    {
        textField.text = text;
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn() //Een fade in animation voor de pop up
    {
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            canvasGroup.alpha = t / fadeTime;
            yield return null;
        }
        canvasGroup.alpha = 1; 
    }
}
