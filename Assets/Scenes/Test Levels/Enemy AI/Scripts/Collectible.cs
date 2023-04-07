using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            if(gameObject.tag == "Cheese")
            {
                playerInventory.CheeseCollected();
                gameObject.SetActive(false);
            }

            else if(gameObject.tag == "Pineapple")
            {
                playerInventory.PineappleCollected();
                gameObject.SetActive(false);
            }

            else if(gameObject.tag == "Pizza")
            {
                playerInventory.PizzaCollected();
                gameObject.SetActive(false);
            }
        }
    }
}
