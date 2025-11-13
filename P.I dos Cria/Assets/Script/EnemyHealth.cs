using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public float maxHealth = 3f;
    private float currentHealth;

    [Header("Recompensa")]
    [Tooltip("Dinheiro que o jogador recebe")]
    [SerializeField] private int moneyReward = 3;

    void Start()
    {
        currentHealth = maxHealth;
        EnemyManager.Instance?.RegisterEnemy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        PlayerMoney.Instance.AddMoney(moneyReward);
        EnemyManager.Instance?.UnregisterEnemy(gameObject);
        SoundEffectorController.PlaySoundEffect(SoundsEffects.Die);
        Destroy(gameObject);
    }
}