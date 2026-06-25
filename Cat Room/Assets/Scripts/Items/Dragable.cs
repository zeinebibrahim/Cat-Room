using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private float dragDepth = 10f;

    private void OnMouseDown() //Class voor mouse click, je kan object draggen wanneer muis ingehouden blijft
    {
        isDragging = true;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = dragDepth;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        offset = transform.position - worldPos;
    }

    private void OnMouseUp() //Mouse loslaten dus object wordt op de plek gezet waar de muis het laatst was
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
