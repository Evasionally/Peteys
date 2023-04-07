using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //for DOTween color change over time

public class StovetopScamper : MonoBehaviour
{

    //String to reperesent the last burner that was turned on
    private string lastBurner;

    public Material bottomLeftBurner;
    public Material bottomRightBurner;
    public Material topLeftBurner;
    public Material topRightBurner;

    Color burnerOff = Color.black;
    Color burnerMid = Color.yellow;
    Color burnerOn = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        //Begin the cycle in the bottom left, so the "previous" burner is in the top left
        lastBurner = "TL";

        //Start all burners as black
        bottomLeftBurner.color = Color.black;
        bottomRightBurner.color = Color.black;
        topLeftBurner.color = Color.black;
        topRightBurner.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {

        if(lastBurner == "TL")
        {
            if(topLeftBurner.color == Color.black)
            {
                //Remove damage ontouch for prev burner
            }
            
            if(bottomLeftBurner.color == Color.black)
            {
                setColorToRed(bottomLeftBurner);

                //Begin damage ontouch for this burner
            
            }
            else if(bottomLeftBurner.color == Color.red)
            {
                //Signify this burner as complete -> move onto the next
                lastBurner = "BL";

                //Set this burner back to black
                setColorToBlack(bottomLeftBurner);

            }
        }
        else if(lastBurner == "BL")
        {
            if(bottomLeftBurner.color == Color.black)
            {
                //Remove damage ontouch for prev burner
            }
            
            if(bottomRightBurner.color == Color.black)
            {
                setColorToRed(bottomRightBurner);

                //Begin damage ontouch for this burner
            
            }
            else if(bottomRightBurner.color == Color.red)
            {
                //Signify this burner as complete -> move onto the next
                lastBurner = "BR";

                //Set this burner back to black
                setColorToBlack(bottomRightBurner);

            }
        }
        else if(lastBurner == "BR")
        {
            if(bottomRightBurner.color == Color.black)
            {
                //Remove damage ontouch for prev burner
            }
            
            if(topRightBurner.color == Color.black)
            {
                setColorToRed(topRightBurner);

                //Begin damage ontouch for this burner
            
            }
            else if(topRightBurner.color == Color.red)
            {
                //Signify this burner as complete -> move onto the next
                lastBurner = "TR";

                //Set this burner back to black
                setColorToBlack(topRightBurner);

            }
        }
        else if(lastBurner == "TR")
        {
            if(topRightBurner.color == Color.black)
            {
                //Remove damage ontouch for prev burner
            }
            
            if(topLeftBurner.color == Color.black)
            {
                setColorToRed(topLeftBurner);

                //Begin damage ontouch for this burner
            
            }
            else if(topLeftBurner.color == Color.red)
            {
                //Signify this burner as complete -> move onto the next
                lastBurner = "TL";

                //Set this burner back to black
                setColorToBlack(topLeftBurner);

            }
        }

        
    }

    public void setColorToRed(Material whichBurner)
    {

        //nMaterial.SetColor("_Color", Color.black);
        whichBurner.DOColor(Color.red, 2);
    }

    public void setColorToBlack(Material whichBurner)
    {

        //nMaterial.SetColor("_Color", Color.black);
        whichBurner.DOColor(Color.black, 2);
    }
}
