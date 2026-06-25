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

    [Header("Fade Animations")]
    [SerializeField] private FadeInOut scratchFade;
    [SerializeField] private FadeInOut biteFade; 

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

        //Start fade animatie
        if (scratchFade != null)
            scratchFade.gameObject.SetActive(true);

        player.PerformAttack(scratchAttack, enemy);
        isMyTurn = false;

        FindFirstObjectByType<TurnManager>().EndTurn();
    }

    public void OnBitePressed()
    {
        if (!isMyTurn) return;

        //Start fade animatie
        if (biteFade != null)
            biteFade.gameObject.SetActive(true);

        player.PerformAttack(biteAttack, enemy);
        isMyTurn = false;

        FindFirstObjectByType<TurnManager>().EndTurn();
    }
}
