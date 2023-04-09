using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SaveFile save;
    
    [NonSerialized] public GameObject zone;
    [NonSerialized] public Transform spawnpoint;

    [Tooltip("Boolean that indicates if this is the first checkpoint in the scene.")]
    public bool isFirstCheckpoint;

    [NonSerialized] public string status;

    // Start is called before the first frame update
    void Start()
    {
        save = new SaveFile($"{gameObject.scene.name}_checkpoints");

        string defaultStatus = isFirstCheckpoint ? "Active" : "Waiting";
        status = save.GetValue(gameObject.name) ?? defaultStatus;

        zone = gameObject.transform.GetChild(0).gameObject;
        spawnpoint = gameObject.transform.GetChild(1);

        if (status == "Inactive")
        {
            Deactivate();
        }
        
        CheckpointManager manager = gameObject.transform.parent.gameObject.GetComponent<CheckpointManager>();
        manager.AddCheckpoint(this);
    }

    public void Activate()
    {
        status = "Active";
    }

    public void Deactivate()
    {
        status = "Inactive";
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        save.Write(gameObject.name, status);
    }
}
