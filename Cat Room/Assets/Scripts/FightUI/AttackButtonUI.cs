using UnityEngine;
using System.Collections.Generic;

public class AttackButtonUI : MonoBehaviour
{
    /*[SerializeField] private PlayerTurnActor playerTurnActor;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private List<ScriptableObject> attackObjects;

    private List<IAttack> attacks = new List<IAttack>();

    private void Awake()
    {
        foreach (var obj in attackObjects)
            attacks.Add(obj as IAttack);

        CreateButtons();
    }

    private void CreateButtons()
    {
        foreach (var attack in attacks)
        {
            GameObject btn = Instantiate(buttonPrefab, buttonContainer);
            btn.SetActive(true);

            AttackButton attackButton = btn.GetComponent<AttackButton>();
            attackButton.Initialize(attack, playerTurnActor);
        }
    }*/
}
