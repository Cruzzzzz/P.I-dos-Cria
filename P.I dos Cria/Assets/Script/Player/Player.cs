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


        // instancia a arma
        GameObject arma = Instantiate(
            weaponPrefab,
            weaponSpawn.position,
            weaponSpawn.rotation,
            transform
        );

        // pega os componentes em QUALQUER parte da arma
        fireAuto = arma.GetComponentInChildren<FireAuto>();
        autoAim = arma.GetComponentInChildren<PlayerAimAndAutoShoot>();

        if (fireAuto == null)
            Debug.LogError("FireAuto NÃO FOI ENCONTRADO na arma!");

        if (autoAim == null)
            Debug.LogError("PlayerAimAndAutoShoot NÃO FOI ENCONTRADO na arma!");

        // conecta fireAuto no autoAim
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
