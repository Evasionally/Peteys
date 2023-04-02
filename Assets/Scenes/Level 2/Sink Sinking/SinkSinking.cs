using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkSinking : MonoBehaviour
{

    //Bool to reference whether or not Petey is currently on the sinkable object
    private bool peteyOnObject = false;
    
    //Position to stop the sinking object at
    [SerializeField]
    public Transform stopPos;

    //Position the sinking object resides at when untouched
    [SerializeField]
    public Transform startPos;

    public float objectSpeed;
    


    // Start is called before the first frame update
    void Start()
    {
        startPos.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //If Petey is ON the object - make it SINK
        if(peteyOnObject == true)
        {
            if(Vector3.Distance(transform.position, stopPos.position) > 0.01f)
            {
                transform.position = Vector3.Lerp(transform.position, stopPos.position, objectSpeed * Time.deltaTime);
                //transform.position = Vector3.MoveTowards(transform.position, stopPos.position, objectSpeed * Time.deltaTime);
            }
        }

        //If Petey is OFF the object - make it FLOAT
        if(peteyOnObject == false)
        {
            //Ensure that the shelf is not already at its starting angle
            if(Vector3.Distance(transform.position, startPos.position) > 0.01f)
            {
                Debug.Log("moving up");
                transform.position = Vector3.MoveTowards(transform.position, startPos.position, objectSpeed * Time.deltaTime);
            }
        }
    }

    public void PeteyOnObject()
    {
        peteyOnObject = !peteyOnObject;
    }
}
