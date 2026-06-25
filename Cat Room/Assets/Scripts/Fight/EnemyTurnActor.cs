using UnityEngine;
using System.Collections;

public class EnemyTurnActor : MonoBehaviour, ITurnActor
{
    [SerializeField] private EnemyCombatant enemy;
    [SerializeField] private PlayerCombatant player;

    [Header("Enemy Attacks")]
    [SerializeField] private ScriptableObject scratchAttackObject;
    [SerializeField] private ScriptableObject biteAttackObject;

    [Header("Fade Effects")]
    [SerializeField] private FadeInOut scratchFade;
    [SerializeField] private FadeInOut biteFade;

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
        CombatEvents.OnTurnStarted.Invoke(enemy);
        StartCoroutine(EnemyAttackRoutine());
    }

    private IEnumerator EnemyAttackRoutine()
    {
        yield return new WaitForSeconds(attackDelay);

        float randomValue = Random.value;
        bool useScratch = false;

        if (randomValue < 0.5f)
        {
            useScratch = true;
        }

        IAttack chosenAttack = scratchAttack;

        if (!useScratch)
        {
            chosenAttack = biteAttack;
        }

        if (useScratch && scratchFade != null)
        {
            scratchFade.gameObject.SetActive(true);
        }

        if (!useScratch && biteFade != null)
        {
            biteFade.gameObject.SetActive(true);
        }

        enemy.PerformAttack(chosenAttack, player);

        FindFirstObjectByType<TurnManager>().EndTurn();
    }
}
