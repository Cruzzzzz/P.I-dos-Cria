using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private float runSpeed = 10f;
    private float inicialSpeed;
    [SerializeField] PlayerRotate rotateScript;

    private Rigidbody2D rb;

    void Start()
    {
        rotateScript = GetComponentInChildren<PlayerRotate>();
        rb = GetComponent<Rigidbody2D>();
        inicialSpeed = speed;
    }
    void Update()
    {
        MovePlayer();
        rotateScript.RotateTowardsMouse();
        playerRun();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;


        rb.linearVelocity = moveDirection * speed;
    }
    void playerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = inicialSpeed;
        }

    }
}
