using UnityEngine;

[CreateAssetMenu(menuName = "Attacks/Scratch")]
public class ScratchAttack : ScriptableObject, IAttack
{
    [SerializeField] private int damage = 10;

    public string Name => "Scratch";
    public int Damage => damage;

    public void Execute(ICombatant user, ICombatant target)
    {
        target.TakeDamage(damage);
    }
}
