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

    public AudioSource audioSource;
    public AudioClip audioClip;

    private string backupTag;

    private void Start() 
    {
        originalPos = transform.localPosition;  
        backupTag = gameObject.tag;  
    }

    
    public void pushButton()
    {
        buttonPushed = true;
        buttonUnpushed = false;

        if(gameObject.tag.Contains("Fan") || gameObject.tag.Contains("Puzzle"))
        {
            audioSource.PlayOneShot(audioClip);
        }

        gameObject.tag = "Untagged";
    }

    public void unpushButton()
    {
        buttonPushed = false;
        buttonUnpushed = true;

        gameObject.tag = backupTag;
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
