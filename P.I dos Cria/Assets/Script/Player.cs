using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MovePlayer();
        RotateTowardsMouse();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;


        rb.linearVelocity = moveDirection * speed;
    }

    void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 direction = (mousePosition - transform.position).normalized;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
