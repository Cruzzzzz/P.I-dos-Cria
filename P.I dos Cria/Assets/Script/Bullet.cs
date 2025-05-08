using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configura��es")]
    public float speed = 10f;
    public int baseDamage = 1;
    public static int damageBonus = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, 4f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int totalDamage = baseDamage + damageBonus;
            collision.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(totalDamage);
            Destroy(gameObject);
        }
    }

    public static void IncreaseDamage(int amount)
    {
        damageBonus += amount;
        Debug.Log($"Dano aumentado para +{damageBonus}");
    }
}

