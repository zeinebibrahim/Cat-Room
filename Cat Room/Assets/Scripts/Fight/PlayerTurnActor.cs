using UnityEngine;

public class PlayerTurnActor : MonoBehaviour, ITurnActor
{
    [SerializeField] private PlayerCombatant player;
    [SerializeField] private EnemyCombatant enemy;
    [SerializeField] private ScriptableObject attackObject;

    private IAttack attack;
    private bool isMyTurn = false;

    private void Awake()
    {
        attack = attackObject as IAttack;
    }

    public void TakeTurn()
    {
        isMyTurn = true;
        CombatEvents.OnTurnStarted?.Invoke(player);
    }

    public void OnAttackButtonPressed()
    {
        if (!isMyTurn) return;
        if (attack == null) { Debug.LogError("Attack is null!"); return; }

        player.PerformAttack(attack, enemy);
        isMyTurn = false;

        FindFirstObjectByType<TurnManager>().EndTurn();
    }
}
