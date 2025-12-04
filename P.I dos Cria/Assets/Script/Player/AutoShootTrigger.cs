using UnityEngine;

public class AutoShootTrigger : MonoBehaviour
{
    public FireAuto fireAuto; // referência ao script que atira
    private Transform currentTarget;

    private void Update()
    {
        if (currentTarget != null && fireAuto != null)
        {
            fireAuto.target = currentTarget; // avisa qual inimigo mirar

            if (fireAuto.canShoot)
                fireAuto.Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentTarget = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.transform == currentTarget)
                currentTarget = null;
        }
    }
}

