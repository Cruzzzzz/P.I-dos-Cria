using UnityEngine.SceneManagement;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        if (SaveSystem.isLoading)
        {
            LoadPlayer();
            SaveSystem.isLoading = false;
        }
        else
        {
            currentHealth = maxHealth;
            if (healthBar != null)
                healthBar.SetMaxHealth(maxHealth);
        }

    }
    public int GetCurrentHealth()
    {
        return currentHealth;
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
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            transform.position = new Vector2(data.posX, data.posY);
            currentHealth = data.vida;
            if (healthBar != null)
                healthBar.SetHealth(currentHealth, maxHealth);

            PlayerMoney.Instance.currentMoney = data.dinheiro;
        }
    }
}