using UnityEngine;
public class EnemyMov : MonoBehaviour
{
    private Transform playerPosition;
    public float speedEnemy = 3f;
    public float followRange = 5f; 

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPosition = player.transform;
        }
    }
    void Update()
    {
        if (playerPosition != null)
        {
            float distance = Vector2.Distance(transform.position, playerPosition.position);


            if (distance <= followRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speedEnemy * Time.deltaTime);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }
}
