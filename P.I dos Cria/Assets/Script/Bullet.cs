using UnityEngine;
public class Bullet : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] public float speed = 10f;
    private float damage;
    [SerializeField] private GameObject bloodEffect;

    private Rigidbody2D rb;


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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(damage);

            if (bloodEffect != null)
            {
                Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);
            }

            if (!PlayerShootPowerups.Instance.bulletPenetration)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
