using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;

public class Bash : MonoBehaviour
{
    public KeyCode input;
    public float bashForce;
    public float coolDownTime;
    public float bashTime;
    public float damage;
    public float coolDownCount;
    public float waitTimer;
    
    private Rigidbody rb;
    private PlayerMovement movementController;
    private bool onCooldown = false;
    private bool isBashing = false;
    
    //Edit by Andy - audio source for bash break sound effects
    public AudioSource aSource;
    public AudioClip aClip;

    public UnityEvent<Bash> OnUse;

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

        // Prevents bashing off ledges to gain huge speed by killing all momentum as soon as
        // Petey leaves the ground while bashing
        if (isBashing && !movementController.grounded)
        {
            movementController.StopMomentum();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isBashing)
        {
            if(collision.gameObject.layer == 11)
            {
                HealthController health = collision.gameObject.GetComponent<HealthController>();
                if (health != null)
                {
                    health.Damage(damage);
                }
            }

            //Edit by Andy - if Petey collides with a Fan activation button
            if(collision.gameObject.tag == "FanButton1")
            {
                //Get fan
                GameObject fan1 = GameObject.Find("Ceiling Fan 1");

                //Set fan to activated
                fan1.GetComponent<FanRotate>().FanActivate();

                //Change the button color to green and animate button push
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                collision.gameObject.GetComponent<ButtonMovement>().pushButton();
            }
            if(collision.gameObject.tag == "FanButton2")
            {
                //Get fan
                GameObject fan2 = GameObject.Find("Ceiling Fan 2");

                //Set fan to activated
                fan2.GetComponent<FanRotate>().FanActivate();

                //Change the button color to green and animate button push
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                collision.gameObject.GetComponent<ButtonMovement>().pushButton();
            }
            if(collision.gameObject.tag == "FanButton3")
            {
                //Get fan
                GameObject fan3 = GameObject.Find("Vent Fan");

                //Set fan to activated
                fan3.GetComponent<FanRotate>().FanActivate();

                //Change the button color to green and animate button push
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                collision.gameObject.GetComponent<ButtonMovement>().pushButton();
            }
            if(collision.gameObject.tag == "GrapplePuzzleButton")
            {
                //Get platform
                GameObject returnPlatform = GameObject.Find("Returning Platform");

                //Set it to activated
                returnPlatform.GetComponent<PlatformActivate>().PlatformmActivate();

                //Change the button color to green and animate button push
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                collision.gameObject.GetComponent<ButtonMovement>().pushButton();
            }

            //Edit by Andy - if Petey collides with a Bashable object like a glass window
            if(collision.gameObject.tag == "Bashable")
            {
                GameObject bashedObj = collision.gameObject;

                aSource.PlayOneShot(aClip);

                //Instantiate(bashedObj, transform.position, transform.rotation);
                //bashedObj.GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 5);
                Destroy(bashedObj);
            }


        }
    }

    private void Cooldown()
    {
        onCooldown = true;
        StartCoroutine(CooldownTimer());
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
        movementController.StopMomentum();
        isBashing = false;
        Cooldown();
    }

    IEnumerator CooldownTimer()
    {
        waitTimer = Time.deltaTime;
        coolDownCount = coolDownTime;
        BashCountTimer();
        while (waitTimer<coolDownTime)
        {
            yield return new WaitForSeconds(1);
            if(coolDownCount == 1)
                break;
            coolDownCount--;
            BashCountTimer();
        }
        coolDownCount = 0;
        BashCountTimer();
    }

    public void BashCountTimer()
    {
        OnUse.Invoke(this);
    }
}
