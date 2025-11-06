using UnityEngine;
using UnityEngine.AI;
public class EnemyMov : MonoBehaviour
{
    private Transform playerPosition;
    public float speedEnemy = 3f;
    public float followRange = 5f; 
    private NavMeshAgent agent;
    bool isFollowing;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        if (player != null)
        {
            playerPosition = player.transform;
        }
        //agent.SetDestination(playerPosition.position);
    }
    void Update()
    {
        /*
        if (playerPosition != null)
        {
            float distance = Vector2.Distance(transform.position, playerPosition.position);


            if (distance <= followRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speedEnemy * Time.deltaTime);
            }
        }
        */
        if (!isFollowing)
            return;

        agent.SetDestination(playerPosition.position);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }
    private void OnBecameVisible()
    {
        isFollowing = true;
    }
}
