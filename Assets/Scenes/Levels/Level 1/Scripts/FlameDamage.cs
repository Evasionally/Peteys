using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDamage : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Damageable")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce (transform.up * -2000);
            other.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * 3000);
        }
    }
}
