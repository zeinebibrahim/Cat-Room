using UnityEngine;
using TMPro;

public class TurnTextController : MonoBehaviour
{
    [SerializeField] private TMP_Text turnText;

    private void OnEnable()
    {
        CombatEvents.OnTurnStarted += UpdateTurnText;
    }

    private void OnDisable()
    {
        CombatEvents.OnTurnStarted -= UpdateTurnText;
    }

    private void UpdateTurnText(ICombatant combatant)
    {
        var player = FindFirstObjectByType<PlayerCombatant>();
        var enemy = FindFirstObjectByType<EnemyCombatant>();

        if (player.IsDead)
        {
            turnText.text = "Enemy wins!";
            return;
        }

        if (enemy.IsDead)
        {
            turnText.text = "You won!";
            return;
        }

        if (combatant is PlayerCombatant)
            turnText.text = "It's your turn!";
        else
            turnText.text = "It's enemy's turn!";
    }
}
