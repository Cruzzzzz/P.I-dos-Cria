using UnityEngine;

public class AutoAimShoot : MonoBehaviour
{
    public float aimRange = 10f;       // distância pra procurar inimigos
    public float rotateSpeed = 10f;    // suavidade da rotação
    public FireAuto fireAuto;          // recebe do Player no Start

    void Update()
    {
        Transform target = FindClosestEnemy();

        fireAuto.target = target; // passa o target pro FireAuto

        if (target != null)
        {
            AimAtTarget(target);
        }
    }

    Transform FindClosestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, aimRange);

        float minDist = Mathf.Infinity;
        Transform closest = null;

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float d = Vector2.Distance(transform.position, hit.transform.position);
                if (d < minDist)
                {
                    minDist = d;
                    closest = hit.transform;
                }
            }
        }

        return closest;
    }

    void AimAtTarget(Transform target)
    {
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Quaternion targetRot = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRot,
            rotateSpeed * Time.deltaTime
        );
    }
}
