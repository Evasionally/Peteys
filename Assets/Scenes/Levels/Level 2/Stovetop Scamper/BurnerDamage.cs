using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerDamage : MonoBehaviour
{

    //Damage value to give
    public float damage;

    private bool isHeated = false;

    public void HeatUp()
    {
        isHeated = true;
    }

    public void CoolDown()
    {
        isHeated = false;
    }


    private void OnCollisionEnter(Collision collision) 
    {
        var burnerRenderer = this.gameObject.GetComponent<Renderer>();

        if(isHeated == true)
        {
            HealthController hitObject = collision.gameObject.GetComponent<HealthController>();
            if (hitObject == null) return;
        
            hitObject.Damage(damage);

            Debug.Log("Petey has taken " + damage + " damage.");
        }
        
    }
}
