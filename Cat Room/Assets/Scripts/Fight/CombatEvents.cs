using System;

public static class CombatEvents
{
    public static Action<ICombatant> OnTurnStarted;
    public static Action<ICombatant, IAttack> OnAttackUsed;
}
