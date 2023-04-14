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
        
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        float z = Random.Range(-spread, spread);

        Vector3 aim = trueAim + new Vector3(x, y, z);
        
        Debug.DrawRay(transform.position, aim, Color.red, 0.5f);
        return aim;
    }
    
}
