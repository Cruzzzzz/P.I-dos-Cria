
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    

    public HealthBar healthBar; 

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
