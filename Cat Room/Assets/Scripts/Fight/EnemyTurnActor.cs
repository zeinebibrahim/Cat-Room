using UnityEngine;
using System.Collections;

public class EnemyTurnActor : MonoBehaviour, ITurnActor
{
    [SerializeField] private EnemyCombatant enemy;
    [SerializeField] private PlayerCombatant player;

    [Header("Enemy Attacks")]
    [SerializeField] private ScriptableObject scratchAttackObject;
    [SerializeField] private ScriptableObject biteAttackObject;

    [SerializeField] private float attackDelay = 1.5f;

    private IAttack scratchAttack;
    private IAttack biteAttack;

    private void Awake()
    {
        scratchAttack = scratchAttackObject as IAttack;
        biteAttack = biteAttackObject as IAttack;
    }

    public void TakeTurn()
    {
        CombatEvents.OnTurnStarted?.Invoke(enemy);
        StartCoroutine(EnemyAttackRoutine());
    }

    private IEnumerator EnemyAttackRoutine()
    {
        yield return new WaitForSeconds(attackDelay);

        IAttack chosenAttack = (Random.value < 0.5f) ? scratchAttack : biteAttack;

        enemy.PerformAttack(chosenAttack, player);

        FindFirstObjectByType<TurnManager>().EndTurn();
    }
}
