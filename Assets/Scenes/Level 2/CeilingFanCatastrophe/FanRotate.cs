using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate : MonoBehaviour
{
    public float degrees;

    //Target to rotate towards (select in the Unity editor)
    public Transform target;

    //Bool to represent if the ceiling fan has been turned on
    private bool fanActivated = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void FanActivate()
    {
        fanActivated = true;;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Rotate(0, 0, 10 * Time.deltaTime);

        //If Petey is ON the shelf - TILT DOWN
        if(fanActivated == true)
        {                    
            
            transform.RotateAround(target.position, transform.forward, degrees * Time.deltaTime);  
        }
    
    }

    
}
