using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    [NonSerialized] public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    
    [NonSerialized] public Vector3 walkPoint;
    [NonSerialized] public bool walkPointSet = false;
    public float walkPointRange;

    public float sightRange, attackRange, runRange;
    [NonSerialized] public bool playerInSightRange, playerInAttackRange, playerInRunRange;

    private AttackController attackController;
    public enum EnemyType
    {
        Melee,
        Ranged,
        Sniper
    }
    public EnemyType enemyType;

    private void Awake()
    {
        player = GameObject.Find("Petey").transform;
        agent = GetComponent<NavMeshAgent>();

        switch (enemyType)
        {
            case EnemyType.Melee:
                attackController = gameObject.GetComponent<MeleeAttackController>();
                break;
            case EnemyType.Ranged:
                attackController = gameObject.GetComponent<RangedAttackController>();
                break;
            case EnemyType.Sniper:
                attackController = gameObject.GetComponent<SniperAttackController>();
                break;
            default:
                throw new AttackControllerTypeNotSupportedException();
        }
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInRunRange = runRange > 0 && Physics.CheckSphere(transform.position, runRange, whatIsPlayer);

        switch (enemyType)
        {
            case EnemyType.Melee:
                if (playerInSightRange && !playerInAttackRange) ChasePlayer();
                else if (playerInSightRange && playerInAttackRange) attackController.BeginAttack();
                else Patroling();
                break;
            case EnemyType.Ranged:
                if (playerInRunRange) RunAway();
                else if (playerInSightRange && playerInAttackRange) attackController.BeginAttack();
                else Patroling();
                break;
            case EnemyType.Sniper:
                if (playerInSightRange && playerInAttackRange) attackController.BeginAttack();
                break;
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
            SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    /// <summary>
    /// Run away little girl, run away!
    /// </summary>
    private void RunAway()
    {
        Vector3 runDirection = transform.position - player.transform.position;
        runDirection.y = 0;

        Debug.DrawRay(transform.position, runDirection, Color.blue, 0.1f);
        agent.SetDestination(runDirection);
    }


    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }  
}

public class AttackControllerTypeNotSupportedException : Exception
{
    public AttackControllerTypeNotSupportedException() {}
    public AttackControllerTypeNotSupportedException(string message) : base(message) {}
    
    public AttackControllerTypeNotSupportedException(string message, Exception innerException) : base(message, innerException) {}
}
