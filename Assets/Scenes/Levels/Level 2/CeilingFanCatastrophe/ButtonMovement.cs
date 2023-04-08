using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    private bool buttonPushed = false;

    private bool buttonUnpushed = false;

    public Vector3 destination;

    private Vector3 originalPos;

    public float speed;

    private void Start() 
    {
        originalPos = transform.localPosition;    
    }

    public void pushButton()
    {
        buttonPushed = true;
        buttonUnpushed = false;
    }

    public void unpushButton()
    {
        buttonPushed = false;
        buttonUnpushed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPushed == true)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destination, speed * Time.deltaTime);   
        }

        if(buttonUnpushed == true)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPos, speed * Time.deltaTime);   
        }
    }
}
