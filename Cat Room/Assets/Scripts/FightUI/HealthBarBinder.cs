using UnityEngine;

public class HealthBarBinder : MonoBehaviour
{
    [SerializeField] private MonoBehaviour combatantObject;
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        ICombatant combatant = combatantObject as ICombatant;
        healthBar.Initialize(combatant);
    }
}
