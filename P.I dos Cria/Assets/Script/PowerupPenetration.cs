using UnityEngine;

public class PowerupPenetration : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerShootPowerups.Instance.bulletPenetration = true;
            Debug.Log("Power-up de Penetração Ativado!");

            Destroy(gameObject);
        }
    }
}
