using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCheese {get; private set;}
    public int NumberOfPineapples {get; private set;}
    public int NumberOfPizzas {get; private set;}

    public UnityEvent<PlayerInventory> OnCollected;

    public void CheeseCollected()
    {
        NumberOfCheese++;
        OnCollected.Invoke(this);
    }

    public void PineappleCollected()
    {
        NumberOfPineapples++;
        OnCollected.Invoke(this);
    }
    
    public void PizzaCollected()
    {
        NumberOfPizzas++;
        OnCollected.Invoke(this);
    }

}
