using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private float dragDepth = 10f;

    private void OnMouseDown()
    {
        isDragging = true;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = dragDepth;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        offset = transform.position - worldPos;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (!isDragging) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = dragDepth;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos) + offset;
        transform.position = worldPos;
    }
}
