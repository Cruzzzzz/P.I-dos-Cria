using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    

    void Start()
    {
        currentHealth = maxHealth;
        EnemyManager.Instance?.RegisterEnemy(gameObject);
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
        EnemyManager.Instance?.UnregisterEnemy(gameObject);
        SoundEffectorController.PlaySoundEffect(SoundsEffects.Die);
        Destroy(gameObject); 
    }
}
