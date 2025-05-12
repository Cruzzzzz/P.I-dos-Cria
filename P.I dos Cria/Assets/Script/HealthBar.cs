using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthSlider; 

    private float maxHealth;

    public void SetMaxHealth(float max)
    {
        maxHealth = max;
        SetHealth(maxHealth);
    }

    public void SetHealth(float currentHealth)
    {
        if (healthSlider != null && maxHealth > 0)
        {
            healthSlider.fillAmount = currentHealth / maxHealth;
        }
    }

    public void SetHealth(float currentHealth, float maxHealth)
    {
        SetMaxHealth(maxHealth);
        SetHealth(currentHealth);
    }
}