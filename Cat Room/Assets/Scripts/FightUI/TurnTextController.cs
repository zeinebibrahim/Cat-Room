using UnityEngine;
using TMPro;

public class TurnTextController : MonoBehaviour
{
    [SerializeField] private TMP_Text turnText;

    [Header("Win/Lose Canvases")]
    [SerializeField] private GameObject youWinCanvas;
    [SerializeField] private GameObject youLostCanvas;

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

        // --- Check win/lose ---
        if (player.IsDead)
        {
            turnText.text = "Enemy wins!";
            youLostCanvas.SetActive(true);
            youWinCanvas.SetActive(false);
            return;
        }

        if (enemy.IsDead)
        {
            turnText.text = "You won!";
            youWinCanvas.SetActive(true);
            youLostCanvas.SetActive(false);
            return;
        }

        // --- Normal turn text ---
        if (combatant is PlayerCombatant)
            turnText.text = "It's your turn!";
        else
            turnText.text = "It's enemy's turn!";
    }
}
