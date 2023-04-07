using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StateManager : MonoBehaviour
{
    [Tooltip("The checkpoint that this GameObject is associated with.")]
    public GameObject associatedCheckpoint;

    private bool selfDestruct = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDestroy()
    {
        if (selfDestruct) return;
        
    }
}
