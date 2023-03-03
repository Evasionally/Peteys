using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls the health of a GameObject, and allows for damage to be applied to it.
/// </summary>
public class HealthController : MonoBehaviour
{
    // Current health of this Game Object
    private float currentHealth;
    
    [Tooltip("The maximum health of this Game Object.")]
    public float maxHealth;
    
    [Tooltip("Optional value to set the starting health of this Game Object.")]
    public float startingHealth = -1;

    private void Start()
    {
        currentHealth = startingHealth == -1 ? startingHealth : maxHealth;
    }
    
    /// <summary>
    /// Applies damage to the game object.
    /// </summary>
    /// <param name="amount">Amount of damage to apply.</param>
    public void Damage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Applies healing to the game object.
    /// </summary>
    /// <param name="amount"></param>
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}