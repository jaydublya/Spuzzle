using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float Health;

    //Patrolling
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Vector3.Distance(transform.position, player.position) <= sightRange;
        playerInAttackRange = Vector3.Distance(transform.position, player.position) <= attackRange;

        if (playerInSightRange)
        {
            if (playerInAttackRange)
                AttackPlayer();
            else
                ChasePlayer();
        }
        else
            Patrolling();
    }

    private void Patrolling()
    {
        if (walkPointSet)
            agent.SetDestination(walkpoint);
        else
            SearchWalkPoint();

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        walkpoint = new Vector3(
            transform.position.x + Random.Range(-walkPointRange, walkPointRange), 
            transform.position.y, 
            transform.position.z + Random.Range(-walkPointRange, walkPointRange));

        if (NavMesh.FindClosestEdge(walkpoint, out NavMeshHit hit, 0))
            walkPointSet = Vector3.Distance(walkpoint, hit.position) <= 0.5f;
    }   
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack Code Here
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);




            ///

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0) Invoke(nameof(DestroyEnemy), 2f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
