using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
    [SerializeField] private UnityEvent onClick;

    private void OnMouseDown()
    {
        if (!enabled) return;

        Debug.Log("Clicked on: " + gameObject.name);
        onClick?.Invoke();
    }
}
