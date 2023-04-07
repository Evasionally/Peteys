using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTilting : MonoBehaviour
{

    //Degrees by which to rotate by (select in the Unity editor)
    public float degrees;

    //Target to rotate towards (select in the Unity editor)
    public Transform target;

    public Transform stopPos;

    public Transform startPos;

    private bool peteyOnShelf = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos.position = transform.position;
    }

    public void PeteyOnShelf()
    {
        peteyOnShelf = !peteyOnShelf;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 0, 10 * Time.deltaTime);

        //If Petey is ON the shelf - TILT DOWN
        if(peteyOnShelf == true)
        {
            Debug.Log("Petey is on the shelf and it should be tilting");
            //Ensure that the shelf is not already at max tilt
            if(Vector3.Distance(transform.position, stopPos.position) > 0.01f)
            {
                transform.RotateAround(target.position, transform.forward, degrees * Time.deltaTime);  
            }
        }

        //If Petey is OFF the shelf - TILT UP
        if(peteyOnShelf == false)
        {
            //Ensure that the shelf is not already at its starting angle
            if(Vector3.Distance(transform.position, startPos.position) > 0.01f)
            {
                transform.RotateAround(target.position, transform.forward, -(degrees) * Time.deltaTime);  
            }
        }
    
    }
}
