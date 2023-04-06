using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bash : MonoBehaviour
{
    public KeyCode input;
    public float bashForce;
    public float coolDownTime;
    public float bashTime;
    public float damage;
    
    private Rigidbody rb;
    private PlayerMovement movementController;
    private bool onCooldown = false;
    private bool isBashing = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        movementController = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(input) && !onCooldown && movementController.grounded &&!isBashing)
        {
            EnterBash();
            rb.AddForce(gameObject.transform.forward * (bashForce * 1f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isBashing)
        {
            HealthController health = collision.gameObject.GetComponent<HealthController>();
            if (health != null)
            {
                health.Damage(damage);
            }
        }
    }

    private void Cooldown()
    {
        onCooldown = true;
        Invoke(nameof(CooldownEnd), coolDownTime);
    }

    private void CooldownEnd()
    {
        onCooldown = false;
    }

    private void EnterBash()
    {
        isBashing = true;
        movementController.frictionless = true;
        Invoke(nameof(ExitBash), bashTime);
    }

    private void ExitBash()
    {
        movementController.frictionless = false;
        isBashing = false;
        Cooldown();
    }
}
