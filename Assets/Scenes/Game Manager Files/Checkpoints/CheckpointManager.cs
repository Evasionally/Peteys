using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private SaveFile save;

    /// <summary>
    /// The current status of the checkpoint. Can either be "Waiting", "Current", or "Deactive"
    /// </summary>
    public string status;

    // Start is called before the first frame update
    void Start()
    {
        save = new SaveFile($"{gameObject.scene.name}_checkpoints");
        status = save.GetValue(gameObject.name) ?? "Waiting";
    }

    public void MakeCurrent()
    {
        status = "Current";
    }

    public void Deactive()
    {
        status = "Deactive";
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        save.Write(gameObject.name, status);
    }
}
