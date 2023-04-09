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
        componentText.text = bashInformation.coolDownCount.ToString();
    }

    public void UpdateCheeseText(Grapple cheeseInventory)
    {
        //componentText.text = cheeseInventory.NumberOfPizzas.ToString();
    }
}
