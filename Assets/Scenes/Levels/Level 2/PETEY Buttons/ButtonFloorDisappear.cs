using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFloorDisappear : MonoBehaviour
{

    //Game objects for the goldenPetey and the buttons
    [SerializeField]
    private GameObject goldenPetey1;

    [SerializeField]
    private GameObject pButton;

    [SerializeField]
    private GameObject e1Button;

    [SerializeField]
    private GameObject tButton;

    [SerializeField]
    private GameObject e2Button;

    [SerializeField]
    private GameObject yButton;

    //Strings to represent the correct button sequence and the current one pressed by the player
    private string correctSequence;

    private string currentSequence;

    //Audio source for the correct sound effect
    public AudioSource correctSource;
    public AudioClip correctClip;

    //Audio source for the incorrect sound effect
    public AudioSource incorrectSource;
    public AudioClip incorrectClip;

    //Audio source for the victory sound effect
    public AudioSource victorySource;
    public AudioClip victoryClip;


    // At the start, declare the correct sequence (PETEY), the current sequence (blank), and set the treasure to inactive
    void Start()
    {
        ButtonLetter.SendLetterValue += AddValueAndCheckSequence;
        correctSequence = "PETEY";
        currentSequence = "";
        goldenPetey1.SetActive(false);
    }

    //Use info from SendLetterValue to update the current sequence
    private void AddValueAndCheckSequence(string buttonLetter)
    {

        //Renderers for the buttons so I can change their color
        var pButtonRenderer = pButton.GetComponent<Renderer>();
        var e1ButtonRenderer = e1Button.GetComponent<Renderer>();
        var tButtonRenderer = tButton.GetComponent<Renderer>();
        var e2ButtonRenderer = e2Button.GetComponent<Renderer>();
        var yButtonRenderer = yButton.GetComponent<Renderer>();

        //Add the first letter of the button's name (will be P, E, T, or Y) to the sequence
        currentSequence += buttonLetter.Substring(0, 1);

        //If the current sequence is WRONG, reset the sequence
        if(currentSequence != correctSequence.Substring(0, currentSequence.Length))
        {
            //Reset sequence to nothing
            currentSequence = "";

            //Reset all buttons back to red and initial height
            pButtonRenderer.material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            pButton.transform.localPosition = new Vector3(0f, 0f, 0f);
            pButton.tag = "PeteyButton";
            e1ButtonRenderer.material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            e1Button.transform.localPosition = new Vector3(0f, 0f, 0f);
            e1Button.tag = "PeteyButton";
            tButtonRenderer.material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            tButton.transform.localPosition = new Vector3(0f, 0f, 0f);
            tButton.tag = "PeteyButton";
            e2ButtonRenderer.material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            e2Button.transform.localPosition = new Vector3(0f, 0f, 0f);
            e2Button.tag = "PeteyButton";
            yButtonRenderer.material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            yButton.transform.localPosition = new Vector3(0f, 0f, 0f);
            yButton.tag = "PeteyButton";
            
            //Play an incorrect sound effect
            incorrectSource.PlayOneShot(incorrectClip);

            
        }
        //If the current sequence is CORRECT and FINISHED
        else if(currentSequence == correctSequence)
        {

            //Y button is last button
            yButtonRenderer.material.SetColor("_Color", Color.green);
            yButton.transform.localPosition = new Vector3(0f, -1.5f, 0f);
            yButton.tag = "Untagged";

            //Reset the sequence and reveal the treasure !
            goldenPetey1.SetActive(true);
            currentSequence = "";
            Destroy(gameObject);

            //Play a victory sound effect
            correctSource.PlayOneShot(victoryClip);

        }
        //If the current sequence is CORRECT and UNFINISHED
        else if(currentSequence != "")
        {
            //When a button is pressed, change it to green, pressed, and untag it so that it can't be pressed again
            switch(buttonLetter)
            {
                case "P_Button":
                    pButtonRenderer.material.SetColor("_Color", Color.green);
                    pButton.transform.localPosition = new Vector3(0f, -1.5f, 0f);
                    pButton.tag = "Untagged";
                    break;

                case "E_Button":
                    e1ButtonRenderer.material.SetColor("_Color", Color.green);
                    e1Button.transform.localPosition = new Vector3(0f, -1.5f, 0f);
                    e1Button.tag = "Untagged";
                    break;

                case "E_Button2":
                    e2ButtonRenderer.material.SetColor("_Color", Color.green);
                    e2Button.transform.localPosition = new Vector3(0f, -1.5f, 0f);
                    e2Button.tag = "Untagged";
                    break;

                case "T_Button":
                    tButtonRenderer.material.SetColor("_Color", Color.green);
                    tButton.transform.localPosition = new Vector3(0f, -1.5f, 0f);
                    tButton.tag = "Untagged";
                    break;

            }

            //Play a correct note sound effect
            correctSource.PlayOneShot(correctClip);
        }
    }

    private void OnDestroy()
    {
        ButtonLetter.SendLetterValue -= AddValueAndCheckSequence;

    }
}
