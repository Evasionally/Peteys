using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damageable")
        {
            other.GetComponent<Rigidbody>().AddForce (transform.up * -1000);
        }
    }
}
