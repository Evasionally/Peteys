using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperoniManager : MonoBehaviour
{
    public float damage;
    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    //Edit by Andy - for pressing PETEY/other buttons with pepperoni
    private void OnCollisionEnter(Collision collision)
    {
        //If pepperoni collides with a PETEY button
        if(collision.gameObject.tag == "PeteyButton")
        {
            //Send what letter that button represents to the proper script
            collision.gameObject.GetComponent<ButtonLetter>().ButtonClicked();
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

    }
}
