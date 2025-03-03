using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Reference to the player's transform.
    [SerializeField] private Transform player;

    // Reference to the NavMeshAgent component for pathfinding.
    private NavMeshAgent _navMeshAgent;
    
    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the NavMeshAgent component attached to this object.
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame.
    void Update()
    {
        // If there's a reference to the player...
        if (player)
        {
            // Set the enemy's destination to the player's current position.
            _navMeshAgent.SetDestination(player.position);
        }
    }
}
