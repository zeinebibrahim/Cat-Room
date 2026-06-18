using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour playerActorObject;
    [SerializeField] private MonoBehaviour enemyActorObject;

    private ITurnActor playerActor;
    private ITurnActor enemyActor;

    private bool playerTurn = true;
    private bool gameOver = false;

    private void Awake()
    {
        playerActor = playerActorObject as ITurnActor;
        enemyActor = enemyActorObject as ITurnActor;
    }

    private void Start()
    {
        StartTurn();
    }

    private void StartTurn()
    {
        if (gameOver) return;

        // Check win/lose
        var player = FindFirstObjectByType<PlayerCombatant>();
        var enemy = FindFirstObjectByType<EnemyCombatant>();

        if (player.IsDead)
        {
            CombatEvents.OnTurnStarted?.Invoke(enemy);
            return;
        }

        if (enemy.IsDead)
        {
            CombatEvents.OnTurnStarted?.Invoke(player);
            return;
        }

        if (playerTurn)
            playerActor.TakeTurn();
        else
            enemyActor.TakeTurn();
    }

    public void EndTurn()
    {
        if (gameOver) return;

        var player = FindFirstObjectByType<PlayerCombatant>();
        var enemy = FindFirstObjectByType<EnemyCombatant>();

        if (player.IsDead)
        {
            gameOver = true;
            CombatEvents.OnTurnStarted?.Invoke(enemy); // Enemy wins
            return;
        }

        if (enemy.IsDead)
        {
            gameOver = true;
            CombatEvents.OnTurnStarted?.Invoke(player); // Player wins
            return;
        }

        playerTurn = !playerTurn;
        StartTurn();
    }
}
