using FMOD.Studio;
using System.Collections.Generic;
using UnityEngine;

public class CaosFMODCorrigir : MonoBehaviour
{
    [SerializeField]SettingsSO settings;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SettingsManager.OnSettingsLoaded += ChangeVolume;
        SettingsManager.OnSettingsSaved += ChangeVolume;

        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        SettingsManager.OnSettingsLoaded -= ChangeVolume;
        SettingsManager.OnSettingsSaved -= ChangeVolume;
    }

    private void ChangeVolume()
    {
        settings.masterVCA.setVolume(settings.MasterVolume);
        settings.ostVCA.setVolume(settings.OSTVolume);
        settings.sfxVCA.setVolume(settings.SFXVolume);
        settings.voVCA.setVolume(settings.VOVolume);

        Resolution selectedResolution = settings.resolutions[settings.ResolutionIndex];

        FullScreenMode isFullScreen = settings.WindowMode ? FullScreenMode.Windowed : FullScreenMode.FullScreenWindow;

        // --------- Resolução e tela cheia
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, isFullScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
