using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles damage of this game object.
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
        HealthController hitObject = collision.gameObject.GetComponent<HealthController>();
        if (hitObject == null) return;
        
        Debug.Log("Damage");
        
        hitObject.Damage(damage);
    }
}
