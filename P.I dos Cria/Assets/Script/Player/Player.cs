using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 12f;
    private float inicialSpeed;

    [Header("Joysticks")]
    public Joystick moveJoystick; // joystick de movimento

    [Header("Weapon System")]
    public Transform weaponSpawn;      // onde a arma nasce
    public GameObject weaponPrefab;    // prefab da arma

    private FireAuto fireAuto;
    private PlayerAimAndAutoShoot autoAim;

    private Rigidbody2D rb;
    public PlayerRotate rotateScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inicialSpeed = speed;

        // ============================
        //     INSTANCIA A ARMA
        // ============================
        GameObject arma = Instantiate(
            weaponPrefab,
            weaponSpawn.position,
            weaponSpawn.rotation,
            transform
        );

        // pega os componentes da arma
        fireAuto = arma.GetComponent<FireAuto>();
        autoAim = arma.GetComponent<PlayerAimAndAutoShoot>();

        // conecta os scripts
        autoAim.fireAuto = fireAuto;
    }

    void Update()
    {
            MovePlayer();
            rotateScript.RotateTowardsJoystick();
    }

    void MovePlayer()
    {
        float horizontal = moveJoystick.Horizontal;
        float vertical = moveJoystick.Vertical;

        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        rb.linearVelocity = moveDirection * speed;
    }
}
