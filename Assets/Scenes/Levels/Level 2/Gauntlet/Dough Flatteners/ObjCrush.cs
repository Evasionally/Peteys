using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCrush : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "PeteySmasher")
        {
            Debug.Log("Lol you died");
        }
    }
}
