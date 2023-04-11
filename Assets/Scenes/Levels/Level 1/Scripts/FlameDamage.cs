using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damageable")
        {
            other.GetComponent<Rigidbody>().AddForce (transform.up * 1000);
            other.GetComponent<Rigidbody>().AddForce (transform.forward * 500);
        }
    }
}
