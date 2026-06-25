using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour
{
    [Header("Fade Settings")]
    [SerializeField] private CanvasGroup canvasGroup; // CanvasGroup bepaalt de alpha (transparantie)
    [SerializeField] private float fadeInTime = 0.5f; // Tijd voor fade-in
    [SerializeField] private float fadeOutTime = 0.5f; // Tijd voor fade-out
    [SerializeField] private float stayVisibleTime; // Tijd dat het object volledig zichtbaar blijft

    private void Reset()
    {
        // Automatisch CanvasGroup zoeken of toevoegen
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        // Start de fade animatie zodra het object actief wordt
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        // Begin altijd volledig onzichtbaar
        canvasGroup.alpha = 0;


        for (float t = 0; t < fadeInTime; t += Time.deltaTime)
        {
            canvasGroup.alpha = t / fadeInTime; // Lineaire interpolatie van 0 → 1
            yield return null;
        }
        canvasGroup.alpha = 1; // Zorg dat hij exact op 1 eindigt

        // Wacht terwijl het object zichtbaar blijft
        yield return new WaitForSeconds(stayVisibleTime);


        for (float t = 0; t < fadeOutTime; t += Time.deltaTime)
        {
            canvasGroup.alpha = 1 - (t / fadeOutTime); // Lineaire interpolatie van 1 → 0
            yield return null;
        }
        canvasGroup.alpha = 0; // Zorg dat hij exact op 0 eindigt
        gameObject.SetActive(false);
    }
}

