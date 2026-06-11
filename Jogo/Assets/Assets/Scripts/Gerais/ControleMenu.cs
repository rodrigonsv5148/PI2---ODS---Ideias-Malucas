using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControleMenu : MonoBehaviour
{
    public string pauseMenuname;

    public void Start()
    {
        Time.timeScale = 1;
    }

    public virtual void Update()
    {

    } 

    public void ActivePauseMenu (string sceneName) 
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void ActiveConfigMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void FlipFlopSettings(GameObject setting) 
    {
        if (setting.activeSelf) 
        {
            setting.SetActive(false);
        }else 
        {
            setting.SetActive(true);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
