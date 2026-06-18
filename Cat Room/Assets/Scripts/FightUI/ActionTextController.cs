using UnityEngine;
using TMPro;

public class ActionTextController : MonoBehaviour
{
    [SerializeField] private TMP_Text actionText;

    private void OnEnable()
    {
        CombatEvents.OnAttackUsed += UpdateActionText;
    }

    private void OnDisable()
    {
        CombatEvents.OnAttackUsed -= UpdateActionText;
    }

    private void UpdateActionText(ICombatant user, IAttack attack)
    {
        if (user is PlayerCombatant)
            actionText.text = $"You used {attack.Name}!";
        else
            actionText.text = $"Enemy used {attack.Name}!";
    }
}
