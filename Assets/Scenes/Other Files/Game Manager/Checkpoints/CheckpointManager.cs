using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public int checkpointCount;
    
    private List<Checkpoint> checkpoints = new List<Checkpoint>();
    private GameObject player;
    
    private void Spawn()
    {
        player = GameObject.Find("Petey");

        Checkpoint active = GetCurrentCheckpoint();
        
        player.transform.position = active.spawnpoint.transform.position;
    }

    public void AddCheckpoint(Checkpoint add)
    {
        checkpoints.Add(add);
        if (checkpoints.Count == checkpointCount)
            Spawn();
    }

    public void UpdateCurrentCheckpoint(Checkpoint newActive)
    {
        Checkpoint oldActive = GetCurrentCheckpoint();
        oldActive.Deactivate();
        newActive.Activate();
    }

    private Checkpoint GetCurrentCheckpoint()
    {
        try
        {
            return checkpoints.First(checkpoint => checkpoint != null && checkpoint.status == "Active");
        }
        catch (Exception e)
        {
            // Error is not handled, as this case should NEVER occur. If it does, then something is wrong
            throw new NoActiveCheckpointsException();
        }
    }
}

public class NoActiveCheckpointsException : Exception
{
    public NoActiveCheckpointsException() {}
    public NoActiveCheckpointsException(string message) : base(message) {}
    
    public NoActiveCheckpointsException(string message, Exception innerException) : base(message, innerException) {}
}

