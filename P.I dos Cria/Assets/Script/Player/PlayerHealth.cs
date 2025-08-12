
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
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
    
        PlayerData data = SaveSystem.LoadGame();
        if (data != null)
        {
            transform.position = new Vector2(data.posX, data.posY);
    currentHealth = data.vida;
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }
    public void RestoreFullHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}