using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Configurações")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    [SerializeField]public float baseFireCooldown = 2f;
    [SerializeField] private float currentFireCooldown;
    public bool canShoot = true;

    [Header("Upgrades")]
    [SerializeField] public float fireRateMultiplier = 1f;
    [SerializeField] public float currentDamage = 1f;

    void Start()
    {
        currentFireCooldown = baseFireCooldown;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetDamage(currentDamage);
        SoundEffectorController.PlaySoundEffect(SoundsEffects.Shoot);
        canShoot = false;
        Invoke(nameof(ResetShot), currentFireCooldown * fireRateMultiplier);
    }
    private void ResetShot() => canShoot = true;

}
   