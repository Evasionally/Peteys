using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Player;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
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
                Player.GetComponent<PlayerMovement>().enabled = false;
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

    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        Player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
