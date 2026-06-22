using System.IO;
using UnityEngine;
using System.Text;
using System;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private SettingsSO settings;

    #region JSON things

    private const string settingsFileName = "settings.json";

    private string settingFilePath => Path.Combine(Application.persistentDataPath, settingsFileName);

    #endregion

    public static Action OnSettingsSaved;
    public static Action OnSettingsLoaded;

    private void Awake()
    {
        if (SettingsSOValidation() == false) return;

        LoadSettings();
    }

    public void SaveSettings() 
    {
        if (SettingsSOValidation() == false) return;

        try 
        {
            string json = JsonUtility.ToJson(settings, true);
            File.WriteAllText(settingFilePath, json, Encoding.UTF8);
            Debug.Log($"JSON file {json} was sucessfull saved in: {settingFilePath}");
            OnSettingsSaved?.Invoke();
        }
        catch  (Exception e)
        {
            Debug.LogError($"Error to save JSON file in {settingFilePath}: {e.Message}");
        }
    }

    public void LoadSettings() 
    {
        if (SettingsSOValidation() == false) return;

        if (File.Exists(settingFilePath)) 
        {
            try
            {
                string json = File.ReadAllText(settingFilePath);
                Debug.Log($"Attempting to load settings from: {settingFilePath}");
                Debug.Log($"Loaded JSON: {json}");

                SettingsSO tempSettingsSO = ScriptableObject.CreateInstance<SettingsSO>();
                
                JsonUtility.FromJsonOverwrite(json, tempSettingsSO);

                if (new ValidateSettings(tempSettingsSO).validateSettings() == true) 
                {
                    JsonUtility.FromJsonOverwrite(json, settings);
                    Debug.Log("Settings loaded");
                }
                else 
                {
                    Debug.LogError($"Error to load the settings from {settingFilePath}, reseting to default settings");
                }

                Destroy(tempSettingsSO); 

            } catch (Exception e) 
            {
                Debug.LogError($"Error loading settings from {settingFilePath}: {e.Message}. Resetando para os padões");
                settings.DefaultSettings();
            }
            
        }
        else 
        {
            Debug.Log($"File don't exist's, setting definied to standard");
            settings.DefaultSettings();
        }

        settings.ApplySettings();

        OnSettingsLoaded?.Invoke();
    }


    #region Manager ButtonsValue-settingsSO

    //------------------------------------------ Bool settings
    public void SetWindowMode( bool isWindow) 
    {
        settings.WindowMode = isWindow;
        Debug.Log($"Window mode was set to: {settings.WindowMode}");
    }

    public void SetInteractionMode(bool isinteractible)
    {
        settings.InteractionMode = isinteractible;
        Debug.Log($"Interaction mode was set to: {settings.InteractionMode}");
    }

    //------------------------------------------ number settings

    public void SetResolutionIndex(int newIndex)
    {
        settings.ResolutionIndex = newIndex;
        Debug.Log($"Resolution index was set to: {settings.ResolutionIndex}");
    }

    public void SetFontSize(int newFontSize)
    {
        settings.FontSize = newFontSize;
        Debug.Log($"Font size was set to: {settings.FontSize}");
    }

    public void SetMasterVolume(float newMasterVolume)
    {
        settings.MasterVolume = newMasterVolume;
        Debug.Log($"Master volume was set to: {settings.MasterVolume}");
    }

    public void SetOSTVolume(float newOSTVolume)
    {
        settings.OSTVolume = newOSTVolume;
        Debug.Log($"OST volume was set to: {settings.OSTVolume}");
    }

    public void SetSFXVolume(float newSFXVolume)
    {
        settings.SFXVolume = newSFXVolume;
        Debug.Log($"OST volume was set to: {settings.SFXVolume}");
    }

    public void SetVOVolume(float newVOVolume)
    {
        settings.VOVolume = newVOVolume;
        Debug.Log($"OST volume was set to: {settings.VOVolume}");
    }

    #endregion

    public SettingsSO GetSettingSO() 
    {
        if ( settings != null) {  return settings; }
        else 
        {
            Debug.LogWarning($"Erro, SettingSO is missing in Settings Manager in {this.gameObject.name}");
            return null;
        }
    }

    private bool SettingsSOValidation() 
    {
        if (this.settings == null)
        {
            Debug.LogError($"Settings SO is misssing in {this.gameObject.name}");
            return false;
        }
        return true;
    }
}
