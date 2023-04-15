using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivate : MonoBehaviour
{

    //Bool to represent if the ceiling fan has been turned on
    private bool platformActivated = false;

    public Vector3 destination;

    private Vector3 originalPos;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.localPosition;
    }

    public void PlatformmActivate()
    {
        platformActivated = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 0, 10 * Time.deltaTime);

        //If Petey is ON the shelf - TILT DOWN
        if(platformActivated)
        {                    
            transform.localPosition = Vector3.Lerp(transform.localPosition, destination, speed * Time.deltaTime);   
        }
    
    }

    
}
