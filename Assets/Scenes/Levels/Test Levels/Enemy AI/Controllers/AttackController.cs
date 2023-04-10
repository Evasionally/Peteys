using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackController : MonoBehaviour
{
    public float cooldown;

    [NonSerialized] public bool onCooldown, attacking = false;

    [NonSerialized] public EnemyAI aiController;
    
    public void Start()
    {
        aiController = gameObject.GetComponent<EnemyAI>();
    }

    public abstract void BeginAttack();
}
