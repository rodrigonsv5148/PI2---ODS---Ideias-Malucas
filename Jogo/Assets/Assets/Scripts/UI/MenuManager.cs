using System;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string settingsMenuName;

    [ContextMenu("Ativa config")]
    public void ActiveConfigMenu()
    {
        SceneManager.LoadScene(settingsMenuName, LoadSceneMode.Additive);
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