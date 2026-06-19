using UnityEngine;

public class PauseManager : MenuManager
{
    public void Start()
    {
        Time.timeScale = 1;
    }
    public void ActivePauseMenu()
    {
        Time.timeScale = 0;
        ActiveConfigMenu();
    }
}
