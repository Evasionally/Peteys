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

    private Vector3 shootPosition;

    public new void Start()
    {
        aiController = gameObject.GetComponent<EnemyAI>();
        shootPosition = transform.GetChild(0).position;
    }
    
    public override void BeginAttack()
    {
        if (onCooldown)
            return;
        
        transform.LookAt(aiController.player);
        
        GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity);
        
        shot.GetComponent<Rigidbody>().AddForce(Aim() * shootForce, ForceMode.Impulse);

        Cooldown();
    }

    private Vector3 Aim()
    {
        Vector3 trueAim = aiController.player.transform.position - transform.position;

        Vector3 aim = trueAim + AimAssist(trueAim) + Variation();
        
        Debug.DrawRay(transform.position, aim, Color.red, 0.5f);
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
