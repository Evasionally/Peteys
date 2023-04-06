using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateConveyor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "conveyor")
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
