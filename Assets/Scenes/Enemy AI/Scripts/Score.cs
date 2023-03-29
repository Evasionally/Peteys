using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI componentText;

    void Start()
    {
        componentText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCheeseText(PlayerInventory playerInventory)
    {
        componentText.text = playerInventory.NumberOfCheese.ToString();
    }

    public void UpdatePineappleText(PlayerInventory playerInventory)
    {
        componentText.text = playerInventory.NumberOfPineapples.ToString();
    }

    public void UpdatePizzaText(PlayerInventory playerInventory)
    {
        componentText.text = playerInventory.NumberOfPizzas.ToString();
    }
}
