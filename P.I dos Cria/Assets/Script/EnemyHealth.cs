using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Aqui você pode colocar animação de morte, efeitos, para caso queiram usar.
        SoundEffectorController.PlaySoundEffect(SoundsEffects.Die);
        Destroy(gameObject); 
    }
}
