using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperoniManager : MonoBehaviour
{
    public float damage;
    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
