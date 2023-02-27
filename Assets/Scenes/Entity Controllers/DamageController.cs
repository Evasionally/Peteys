using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles damage of the pepperoni projectile.
/// </summary>
public class DamageController : MonoBehaviour
{
    [Tooltip("The amount of damage that this Game Object does.")]
    public float damage;
    
    /// <summary>
    /// On collision, applies damage to the hit Game Object, if it has health.
    /// </summary>
    /// <param name="collision">The Game Object that this collided with.</param>
    public void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        
        if (hitObject.CompareTag("Damageable"))
        {
            hitObject.GetComponent<HealthController>().Damage(damage);
        }
    }
}
