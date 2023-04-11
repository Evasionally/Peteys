using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFloorDisappear : MonoBehaviour
{


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
            pButton.tag = "PeteyButton";
            pButton.transform.GetChild(0).GetComponent<Renderer>().tag = "ButtonSticker";
            pButton.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            pButton.GetComponent<ButtonMovement>().unpushButton();

            e1ButtonRenderer.material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            e1Button.tag = "PeteyButton";
            e1Button.transform.GetChild(0).GetComponent<Renderer>().tag = "ButtonSticker";
            e1Button.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            e1Button.GetComponent<ButtonMovement>().unpushButton();
        
            tButtonRenderer.material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            tButton.tag = "PeteyButton";
            tButton.transform.GetChild(0).GetComponent<Renderer>().tag = "ButtonSticker";
            tButton.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            tButton.GetComponent<ButtonMovement>().unpushButton();

            e2ButtonRenderer.material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            e2Button.tag = "PeteyButton";
            e2Button.transform.GetChild(0).GetComponent<Renderer>().tag = "ButtonSticker";
            e2Button.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            e2Button.GetComponent<ButtonMovement>().unpushButton();

            yButtonRenderer.material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            yButton.tag = "PeteyButton";
            yButton.transform.GetChild(0).GetComponent<Renderer>().tag = "ButtonSticker";
            yButton.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(0.77f, 0.106f, 0.106f, 1f));
            yButton.GetComponent<ButtonMovement>().unpushButton();
            
            //Play an incorrect sound effect
            incorrectSource.PlayOneShot(incorrectClip);

            
        }
        //If the current sequence is CORRECT and FINISHED
        else if(currentSequence == correctSequence)
        {

            //Y button is last button
            yButton.tag = "Untagged";
            yButton.transform.GetChild(0).GetComponent<Renderer>().tag = "Untagged";

            //Change the button color to green and animate button push
            yButtonRenderer.material.SetColor("_Color", Color.green);
            yButton.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            yButton.GetComponent<ButtonMovement>().pushButton();

            //Play a victory sound effect
            victorySource.PlayOneShot(victoryClip);


            //Reset the sequence and reveal the treasure !
            currentSequence = "";
            Destroy(gameObject);


        }
        //If the current sequence is CORRECT and UNFINISHED
        else if(currentSequence != "")
        {
            buttonLetter = buttonLetter.Replace("Sticker", "Button");
            
            //When a button is pressed, change it to green, pressed, and untag it so that it can't be pressed again
            switch(buttonLetter)
            {
                case "P_Button":
                    //Alter tags to avoid duplicate presses
                    pButton.tag = "Untagged";
                    pButton.transform.GetChild(0).GetComponent<Renderer>().tag = "Untagged";

                    //Change the button color to green and animate button push
                    pButtonRenderer.material.SetColor("_Color", Color.green);
                    pButton.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                    pButton.GetComponent<ButtonMovement>().pushButton();

                    break;

                case "E_Button":
                    //Alter tags to avoid duplicate presses
                    e1Button.tag = "Untagged";
                    e1Button.transform.GetChild(0).GetComponent<Renderer>().tag = "Untagged";

                    //Change the button color to green and animate button push
                    e1ButtonRenderer.material.SetColor("_Color", Color.green);
                    e1Button.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                    e1Button.GetComponent<ButtonMovement>().pushButton();

                    break;

                case "E_Button2":
                    //Alter tags to avoid duplicate presses
                    e2Button.tag = "Untagged";
                    e2Button.transform.GetChild(0).GetComponent<Renderer>().tag = "Untagged";

                    //Change the button color to green and animate button push
                    e2ButtonRenderer.material.SetColor("_Color", Color.green);
                    e2Button.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                    e2Button.GetComponent<ButtonMovement>().pushButton();

                    break;

                case "T_Button":
                    //Alter tags to avoid duplicate presses
                    tButton.tag = "Untagged";
                    tButton.transform.GetChild(0).GetComponent<Renderer>().tag = "Untagged";

                    //Change the button color to green and animate button push
                    tButtonRenderer.material.SetColor("_Color", Color.green);
                    tButton.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                    tButton.GetComponent<ButtonMovement>().pushButton();

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
