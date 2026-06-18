using UnityEngine;
using System.Collections;

public class EnemyTurnActor : MonoBehaviour, ITurnActor
{
    [SerializeField] private EnemyCombatant enemy;
    [SerializeField] private PlayerCombatant player;
    [SerializeField] private ScriptableObject attackObject;
    [SerializeField] private float attackDelay = 1.5f;

    private IAttack attack;

    private void Awake()
    {
        attack = attackObject as IAttack;
    }

    public void TakeTurn()
    {
        CombatEvents.OnTurnStarted?.Invoke(enemy);
        StartCoroutine(EnemyAttackRoutine());
    }

    private IEnumerator EnemyAttackRoutine()
    {
        yield return new WaitForSeconds(attackDelay);

        enemy.PerformAttack(attack, player);

        FindFirstObjectByType<TurnManager>().EndTurn();
    }
}
