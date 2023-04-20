using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityCoolDowns : MonoBehaviour
{
    private TextMeshProUGUI componentText;

    void Start()
    {
        componentText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdatePepperoniCountText(PepperoniProjectile pepperoniInformation)
    {
        componentText.text = pepperoniInformation.bulletsLeft.ToString();
    }

    public void UpdateBashCountdownText(Bash bashInformation)
    {
        if(bashInformation.coolDownCount == 0)
            componentText.text = "Q";
        else
            componentText.text = bashInformation.coolDownCount.ToString();
    }
}
