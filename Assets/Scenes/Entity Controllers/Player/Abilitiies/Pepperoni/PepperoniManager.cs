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

    //Edit by Andy - for pressing PETEY buttons with pepperoni
    private void OnCollisionEnter(Collision collision)
    {
        //If pepperoni collides with a PETEY button
        if(collision.gameObject.tag == "PeteyButton")
        {
            //Send what letter that button represents to the proper script
            collision.gameObject.GetComponent<ButtonLetter>().ButtonClicked();
        }
    }
}
