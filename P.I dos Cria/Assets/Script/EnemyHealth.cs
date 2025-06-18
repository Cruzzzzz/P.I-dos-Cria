using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 3;
    private float currentHealth;

    

    void Start()
    {
        currentHealth = maxHealth;
        EnemyManager.Instance?.RegisterEnemy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= (int)damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        PlayerMoney.Instance.AddMoney(3);
        EnemyManager.Instance?.UnregisterEnemy(gameObject);
        SoundEffectorController.PlaySoundEffect(SoundsEffects.Die);
        Destroy(gameObject); 
    }
}
