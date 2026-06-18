public interface ICombatant
{
    int Health { get; }
    void TakeDamage(int amount);
    void PerformAttack(IAttack attack, ICombatant target);
}
