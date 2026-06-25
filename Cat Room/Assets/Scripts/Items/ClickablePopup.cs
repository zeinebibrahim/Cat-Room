using UnityEngine;

public class ClickablePopup : MonoBehaviour
{
    [SerializeField] private string popupText = "Default popup text"; //Je kan zelf text toevoegen

    private void OnMouseDown()
    {
        if (!gameObject.activeInHierarchy) return;

        PopupUI.Instance.ShowPopup(popupText); //Laat de text van de pop up zien
    }
}