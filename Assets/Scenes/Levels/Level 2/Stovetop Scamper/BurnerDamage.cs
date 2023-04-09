using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerDamage : MonoBehaviour
{

    //Damage value to give
    public float damage;

    


    private void OnCollisionEnter(Collision collision) 
    {
        var burnerRenderer = this.gameObject.GetComponent<Renderer>();

        if(burnerRenderer.material.color != Color.black)
        {
            HealthController hitObject = collision.gameObject.GetComponent<HealthController>();
            if (hitObject == null) return;
        
            hitObject.Damage(damage);

            Debug.Log("Petey has taken " + damage + " damage.");
        }
        
    }
}
