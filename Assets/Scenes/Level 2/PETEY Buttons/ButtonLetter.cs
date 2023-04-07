using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class ButtonLetter : MonoBehaviour
{

    //String containing the name of the button that was just pressed
    public string buttonLetter;

    //At the start, get the button's name
    public void Start()
    {
        //buttonLetter = name.Substring(0, name.IndexOf("_"));
        buttonLetter = name;
    }

    //SendLetterValue sends the button's name/letter (P, E, T, or Y)
    public static event Action<string> SendLetterValue = delegate { };

    //When the button is pressed, send the letter of the button to the game
    public void ButtonClicked()
    {
        SendLetterValue(buttonLetter);

        UnityEngine.Debug.Log(buttonLetter);
    }
}
