using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void OnDestroy()
    {
        HealthController health = gameObject.GetComponent<HealthController>();
        if(health.currentHealth <= 0)
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
}
