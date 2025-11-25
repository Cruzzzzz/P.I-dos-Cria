using UnityEngine;

public class PlayerShootPowerups : MonoBehaviour
{
    public static PlayerShootPowerups Instance;

    public bool bulletPenetration = false;

    private void Awake()
    {
        Instance = this;
    }
}
