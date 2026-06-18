using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float smoothSpeed = 5f;

    private ICombatant target;
    private float maxHealth;
    private float currentFill;

    public void Initialize(ICombatant combatant)
    {
        target = combatant;
        maxHealth = combatant.Health;
        currentFill = 1f;
        fillImage.fillAmount = 1f;
    }

    private void Update()
    {
        if (target == null) return;

        float targetFill = target.Health / maxHealth;

        //Smoothly lerp towards the new value
        currentFill = Mathf.Lerp(currentFill, targetFill, Time.deltaTime * smoothSpeed);

        fillImage.fillAmount = currentFill;
    }
}
