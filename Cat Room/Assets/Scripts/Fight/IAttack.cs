public interface IAttack
{
    string Name { get; }
    int Damage { get; }
    void Execute(ICombatant user, ICombatant target);
}
