using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Configuração Básica")]
    public Slider healthSlider; 
    public void SetMaxHealth(float maxHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }
    public void SetHealth(float currentHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }
    public void SetHealth(float currentHealth, float maxHealth)
    {
        SetMaxHealth(maxHealth);
        SetHealth(currentHealth);
    }
}