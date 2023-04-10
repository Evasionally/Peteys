using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Player;
    public Camera MainCam;
    
    public static bool isPaused;
    private CinemachineBrain camBrain;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        camBrain = MainCam.GetComponent<CinemachineBrain>();
        
        // Ensures the camera is in Smart Update mode if the scene was closed with the pause menu open
        camBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.SmartUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        camBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.FixedUpdate;
        
        Player.GetComponent<PlayerMovement>().enabled = false;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        camBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.SmartUpdate;

        Player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

}
