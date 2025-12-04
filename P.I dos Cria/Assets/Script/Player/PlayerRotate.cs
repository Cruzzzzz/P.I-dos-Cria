using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Joystick aimJoystick;
    public float rotationSpeed = 10f;
    public float deadzone = 0.2f;

    private void Update()
    {
        RotateTowardsJoystick();
    }

    public void RotateTowardsJoystick()
    {
        if (aimJoystick == null)
        {
            Debug.LogError("AIM JOYSTICK NÃO REFERENCIADO!");
            return;
        }

        Vector2 dir = new Vector2(aimJoystick.Horizontal, aimJoystick.Vertical);

        if (dir.magnitude < deadzone)
            return;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90f);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}
