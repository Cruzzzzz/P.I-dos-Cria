using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireCooldown = 2f;
    public bool characterControllerEnable = true;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown; 
        }
    }

    void Shoot()
    {
        if (characterControllerEnable)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            SoundEffectorController.PlaySoundEffect(SoundsEffects.Shoot);
        }
       
    }

}
   