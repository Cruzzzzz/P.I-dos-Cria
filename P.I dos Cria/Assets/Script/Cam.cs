using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
    }
}
