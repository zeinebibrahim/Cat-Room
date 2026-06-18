using UnityEngine;

public class PlayerTurnActor : MonoBehaviour, ITurnActor
{
    [SerializeField] private PlayerCombatant player;
    [SerializeField] private EnemyCombatant enemy;

    [Header("Attacks")]
    [SerializeField] private ScriptableObject scratchAttackObject;
    [SerializeField] private ScriptableObject biteAttackObject;

    private IAttack scratchAttack;
    private IAttack biteAttack;

    private bool isMyTurn = false;

    private void Awake()
    {
        scratchAttack = scratchAttackObject as IAttack;
        biteAttack = biteAttackObject as IAttack;
    }

    public void TakeTurn()
    {
        isMyTurn = true;
        CombatEvents.OnTurnStarted?.Invoke(player);
    }

    public void OnScratchPressed()
    {
        if (!isMyTurn) return;

        player.PerformAttack(scratchAttack, enemy);
        isMyTurn = false;

        FindFirstObjectByType<TurnManager>().EndTurn();
    }

    public void OnBitePressed()
    {
        if (!isMyTurn) return;

        player.PerformAttack(biteAttack, enemy);
        isMyTurn = false;

        FindFirstObjectByType<TurnManager>().EndTurn();
    }
}
