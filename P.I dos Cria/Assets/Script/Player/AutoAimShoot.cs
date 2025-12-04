using UnityEngine;

public class PlayerAimAndAutoShoot : MonoBehaviour
{
    [Header("Joysticks")]
    public Joystick aimJoystick;

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
        HandleAutoShoot();
    }

    void HandleAutoShoot()
    {

    }

    Collider2D FindEnemyInFront()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);

        foreach (var hit in hits)
        {
            Vector2 dirToEnemy = (hit.transform.position - transform.position).normalized;
            float angle = Vector2.Angle(transform.up, dirToEnemy);

            // precisa mover o joystick
            Vector2 aimDir = new Vector2(aimJoystick.Horizontal, aimJoystick.Vertical);
            if (aimDir.magnitude <= aimDeadzone)
                continue;

            if (angle < visionAngle)
                return hit;
        }
        return null;
    }
}
