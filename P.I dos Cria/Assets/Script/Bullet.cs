using UnityEngine;
public class Bullet : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] public float speed = 10f;
    private float damage;

    private Rigidbody2D rb;
    private bool isBeingDestroyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, 4f);
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
        Debug.Log("Dano da bala: " + damage);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBeingDestroyed) return;
        isBeingDestroyed = true;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(damage);
        }
        Destroy(gameObject, 0.5f);
    }
}

