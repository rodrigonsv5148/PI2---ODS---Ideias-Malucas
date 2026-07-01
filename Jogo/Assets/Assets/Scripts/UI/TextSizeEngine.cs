using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class TextSizeEngine : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> textsScene = new List<TextMeshProUGUI>();
    [SerializeField] SettingsSO settings;

    public static TextSizeEngine instance;

    private void Awake()
    {
        Singleton();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        instance = null;

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Singleton() 
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void AdjustTextSize()
    {
        // Resolve problemas com indice a função decrescer
        for (int i = textsScene.Count - 1; i >= 0; i--) 
        {
            if (textsScene[i] == null) 
            {
                textsScene.RemoveAt(i);
            }
            else 
            {
                textsScene[i].fontSize = settings.FontSize;
            }
        }
    }

    private void GetAlltmpros() 
    {
        textsScene = FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.None).ToList();
    }

    public void AddTmpro(TextMeshProUGUI tmpro) 
    {
        if (textsScene.Contains(tmpro)) return;  
        textsScene.Add(tmpro);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GetAlltmpros();
        AdjustTextSize();
    }
}
