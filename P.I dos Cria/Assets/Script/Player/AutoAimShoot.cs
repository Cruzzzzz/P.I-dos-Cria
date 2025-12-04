using UnityEngine;

public class PlayerAimAndAutoShoot : MonoBehaviour
{
    [Header("Joysticks")]
    public Joystick aimJoystick; // joystick da mira

    [Header("Configurações")]
    public float aimDeadzone = 0.2f;
    public float detectionRange = 8f;
    public float visionAngle = 45f;
    public LayerMask enemyLayer;

    [Header("Referências")]
    public FireAuto fireAuto;
    public Transform firePoint;

    private void Update()
    {
        HandleAim();
        HandleAutoShoot();
    }

    void HandleAim()
    {

        Vector2 dir = new Vector2(aimJoystick.Horizontal, aimJoystick.Vertical);

        if (dir.magnitude > aimDeadzone)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        }
    }


    void HandleAutoShoot()
    {
        // raycast em cone pra achar inimigos na frente
        Collider2D enemy = FindEnemyInFront();

        if (enemy != null)
        {
            // manda atirar
            fireAuto.canShoot = true;
        }
        else
        {
            fireAuto.canShoot = false;
        }
    }

    Collider2D FindEnemyInFront()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);

        foreach (var hit in hits)
        {
            Vector2 dirToEnemy = (hit.transform.position - transform.position).normalized;

            float angle = Vector2.Angle(transform.up, dirToEnemy);

            if (angle < visionAngle)
            {
                return hit;
            }
        }

        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
