using UnityEngine;

public class EnemyCombatant : MonoBehaviour, ICombatant
{
    [SerializeField] private int maxHealth = 100;
    public int Health { get; private set; }
    public bool IsDead => Health <= 0;

    private void Awake()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
    }

    public void PerformAttack(IAttack attack, ICombatant target)
    {
        attack.Execute(this, target);
        CombatEvents.OnAttackUsed?.Invoke(this, attack);
    }
}
