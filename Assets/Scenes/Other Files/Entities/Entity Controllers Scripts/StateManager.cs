using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StateManager : MonoBehaviour
{
    [Tooltip("The checkpoint that this GameObject is associated with.")]
    public GameObject associatedCheckpoint;

    [Tooltip("The name of the save that this state manager will write to. Typically the" +
             "type of object this is attached to.")]
    public string saveName;

    private bool selfDestruct = false;
    private SaveFile save;
    private string state;
    
    // Start is called before the first frame update
    void Start()
    {
        save = new SaveFile($"{gameObject.scene.name}_{saveName}");
        
        state = save.GetValue(gameObject.name) ?? "Active";

        bool isInactive = state == "Inactive";

        bool checkPointInactive = associatedCheckpoint.GetComponent<Checkpoint>().status == "Inactive";
        
        if (isInactive || checkPointInactive)
        {
            selfDestruct = true;
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        if (selfDestruct) return;

        state = "Inactive";
        save.Write(gameObject.name, state);
    }
}
