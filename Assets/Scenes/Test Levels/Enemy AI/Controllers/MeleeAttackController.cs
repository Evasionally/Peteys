using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController: AttackController
{
    public float attackTime;
    public float speedUp;
    
    private float baseSpeed;
    private float baseAcceleration;
    public bool attacking;
    
    public new void Start()
    {
        aiController = gameObject.GetComponent<EnemyAI>();
        baseSpeed = aiController.agent.speed;
        baseAcceleration = aiController.agent.acceleration;
    }
    
    public override void BeginAttack()
    {
        // If attack is on cooldown, just sit idle and watch player. Too tired to attack!
        if (onCooldown)
        {
            aiController.agent.SetDestination(transform.position);
            transform.LookAt(aiController.player);
            return;
        }
        
        if (!attacking)
        {
            attacking = true;
            Invoke(nameof(EndAttack), attackTime);
        }
        
        Attack();
    }

    private void EndAttack()
    {
        attacking = false;
        onCooldown = true;

        aiController.agent.speed = baseSpeed;
        aiController.agent.acceleration = baseAcceleration;
        
        Invoke(nameof(EndCooldown), cooldown);
    }
    

    private void EndCooldown()
    {
        onCooldown = false;
    }
    

    private void Attack()
    {
        aiController.agent.SetDestination(aiController.player.position);
        transform.LookAt(aiController.player);
        
        aiController.agent.speed += speedUp * Time.deltaTime;
        aiController.agent.acceleration += speedUp * Time.deltaTime;
    }
}
