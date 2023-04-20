using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDamage : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Damageable")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce (transform.up * -1000);
        }
    }
}
