using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : MonoBehaviour
{
    public KeyCode input;
    public float bashForce;
    public float coolDownTime;
    public float frictionlessTime;
    
    private Rigidbody rb;
    private PlayerMovement movementController;
    private bool onCooldown = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        movementController = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(input) && !onCooldown && movementController.grounded)
        {
            RemoveFriction();
            rb.AddForce(gameObject.transform.forward * (bashForce * 1f));
            Cooldown();
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

    private void RemoveFriction()
    {
        movementController.frictionless = true;
        Invoke(nameof(ReinstateFriction), frictionlessTime);
    }

    private void ReinstateFriction()
    {
        movementController.frictionless = false;
    }
}
