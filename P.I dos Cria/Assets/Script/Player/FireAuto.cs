using UnityEngine;

public class FireAuto : MonoBehaviour
{
    [Header("Configurações")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float baseFireCooldown = 1f;
    public bool canShoot = true;


    [Header("Upgrades")]
    public float fireRateMultiplier = 1f;
    public float currentDamage = 1f;

    [Header("Auto Aim")]
    public Transform target; // vai receber do AutoAimShoot

    void Update()
    {

        if (target == null) return;      // sem inimigo → não atira

        if (!canShoot) return;           // esperando cooldown → não atira

        // só atira se o inimigo estiver no campo de visão
        if (PodeVerOInimigo())
        {
            Shoot();
        }
    }
    private bool PodeVerOInimigo()
    {
        Vector2 dir = target.position - firePoint.position;

        RaycastHit2D hit = Physics2D.Raycast(
            firePoint.position,
            dir.normalized,
            100
        );

        return hit && hit.collider.CompareTag("Enemy");
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
        {
            b.SetDamage(currentDamage);
        }

        SoundEffectorController.PlaySoundEffect(SoundsEffects.Shoot);

        canShoot = false;
        Invoke(nameof(ResetShot), baseFireCooldown * fireRateMultiplier);
    }

    private void ResetShot()
    {
        canShoot = true;
    }
}

