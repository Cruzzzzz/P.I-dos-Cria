using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Configuraçôes")]
    [SerializeField]public float speed = 10f;
    [SerializeField]public float baseDamage = 1;


    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, 4f);
        //baseDamage = GameController.instance.shopSystem.Damage_Up(baseDamage);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(baseDamage);
            Destroy(gameObject); 
        }
        if (collision.gameObject.CompareTag("Tree"))
        {
            Destroy(gameObject);
        }
        
    }


}

