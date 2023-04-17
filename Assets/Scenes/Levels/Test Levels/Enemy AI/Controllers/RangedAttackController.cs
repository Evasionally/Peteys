using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RangedAttackController: AttackController
{
    public GameObject projectile;
    public float shootForce;
    public float spread;
    public float assistance;
    public bool attacking;

    private Transform shotSpawn;

    public new void Start()
    {
        attacking = false;
        aiController = gameObject.GetComponent<EnemyAI>();
        shotSpawn = transform.GetChild(0);
    }
    
    public override void BeginAttack()
    {
        if (onCooldown)
        {
            attacking = false;
            return;
        }
        
        attacking = true;
        transform.LookAt(aiController.player);
        
        GameObject shot = Instantiate(projectile, shotSpawn.position, Quaternion.identity);
        
        shot.GetComponent<Rigidbody>().AddForce(Aim() * shootForce, ForceMode.Impulse);

        Cooldown();
    }

    private Vector3 Aim()
    {
        Vector3 trueAim = aiController.player.transform.position - shotSpawn.position;

        Vector3 aim = trueAim + AimAssist(trueAim) + Variation();
        
        Debug.DrawRay(shotSpawn.position, aim, Color.red, 0.5f);
        return aim;
    }

    private Vector3 Variation()
    {
        float xVariance = Random.Range(-spread, spread);
        float yVariance = Random.Range(-spread, spread);
        float zVariance = Random.Range(-spread, spread);

        return new Vector3(xVariance, yVariance, zVariance);
    }

    private Vector3 AimAssist(Vector3 currentAim)
    {
        float assistY = assistance / currentAim.magnitude;

        return new Vector3(0, assistY, 0);
    }
    
}
