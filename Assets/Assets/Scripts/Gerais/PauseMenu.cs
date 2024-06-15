using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : ControleMenu
{
    [SerializeField] private GameObject pauseMenu;
    private bool pause = false;

    public override void Update()
    {
        if (pause == false &&  Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            pause = true;
        }
        else if (pause == true && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            pause = false;
        }
    }

    public void mainMenu (string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }

    public void continueGame() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        pause = false;
    }
}
