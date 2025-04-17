using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] PlayerRotate rotateScript;

    private Rigidbody2D rb;

    void Start()
    {
        rotateScript = GetComponentInChildren<PlayerRotate>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MovePlayer();
        rotateScript.RotateTowardsMouse();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;


        rb.linearVelocity = moveDirection * speed;
    }
}
