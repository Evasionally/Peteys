using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        Checkpoint checkpoint = gameObject.transform.parent.gameObject.GetComponent<Checkpoint>();

        if (checkpoint.status == "Active") return;

        CheckpointManager manager = checkpoint.transform.parent.gameObject.GetComponent<CheckpointManager>();
        manager.UpdateCurrentCheckpoint(checkpoint);
    }
}
