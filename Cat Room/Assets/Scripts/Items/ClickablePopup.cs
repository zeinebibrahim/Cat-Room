using UnityEngine;

public class ClickablePopup : MonoBehaviour
{
    [SerializeField] private string popupText = "Default popup text";

    private void OnMouseDown()
    {
        if (!gameObject.activeInHierarchy) return;

        PopupUI.Instance.ShowPopup(popupText);
    }
}