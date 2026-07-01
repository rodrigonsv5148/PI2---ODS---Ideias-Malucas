using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour
{
    public void ReturnButton() 
    {
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }

    public void ResetButtonState() 
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
