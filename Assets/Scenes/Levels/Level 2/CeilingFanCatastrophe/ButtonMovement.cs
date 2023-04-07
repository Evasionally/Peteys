using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    private bool buttonPushed = false;

    public Vector3 destination;

    public float speed;

    public void pushButton()
    {
        buttonPushed = true;
    }

    public void unpushButton()
    {
        buttonPushed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPushed == true)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destination, speed * Time.deltaTime);   
        }
    }
}
