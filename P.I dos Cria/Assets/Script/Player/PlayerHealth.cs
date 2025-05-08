
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [Header("Configurações Básicas")]
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }
    public void RestoreFullHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
        Debug.Log("Vida totalmente restaurada!");
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player morreu!");
    }
}