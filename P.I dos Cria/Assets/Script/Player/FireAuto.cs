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
        if (target != null && canShoot)
        {
            Shoot();
        }
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

