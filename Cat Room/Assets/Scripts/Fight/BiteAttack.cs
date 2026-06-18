using UnityEngine;

[CreateAssetMenu(menuName = "Attacks/Bite")]
public class BiteAttack : ScriptableObject, IAttack
{
    [SerializeField] private int damage = 15;

    public string Name => "Bite";
    public int Damage => damage;

    public void Execute(ICombatant user, ICombatant target)
    {
        target.TakeDamage(damage);
    }
}
