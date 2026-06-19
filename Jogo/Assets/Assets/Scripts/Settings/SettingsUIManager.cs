using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(SettingsManager))]
public class SettingsUIManager : MonoBehaviour
{
    SettingsSO settingsSO;
    SettingsManager settingsManager;

    #region UI elements

    [SerializeField] TMP_Dropdown dResolutions;
    [SerializeField] TMP_Dropdown dFontSize;
    [SerializeField] Toggle tIsInteractable;
    [SerializeField] Toggle tIsWindowned;
    [SerializeField] Slider sMasterVolume;
    [SerializeField] Slider sOSTVolume;
    [SerializeField] Slider sSFXVolume;
    [SerializeField] Slider sVOVolume;
    [SerializeField] Button saveButton;

    List<Selectable> UIelements;
    #endregion

    private void Awake()
    {
        settingsManager = GetComponent<SettingsManager>();
        settingsSO = settingsManager.GetSettingSO();

        UIelements = new List<Selectable>
        {
            dResolutions, dFontSize,
            tIsInteractable, tIsWindowned,
            sMasterVolume, sOSTVolume, sSFXVolume, sVOVolume,
            saveButton
        };

        populateDropdown(settingsSO?.GetResolutions(), dResolutions);

        AddListeners();

        SettingsManager.OnSettingsLoaded += UpdateUIBasedOnSettings;

        SettingsManager.OnSettingsSaved += SettingsSavedFeedback;
    }

    private void Start()
    {
        UpdateUIBasedOnSettings();
    }

    private void OnDestroy()
    {
        RemoveListeners();

        SettingsManager.OnSettingsLoaded -= UpdateUIBasedOnSettings;

        SettingsManager.OnSettingsSaved -= SettingsSavedFeedback;
    }

    #region Actions UI elements
    private void SetResolutionIndex(int newResolutionIndex)
    {
        settingsSO.ResolutionIndex = newResolutionIndex;
    }
    private void SetFontSize(int newFontSize)
    {
        settingsSO.FontSize = newFontSize;
    }
    private void SetInteractable(bool isInteractable)
    {
        settingsSO.InteractionMode = isInteractable;
    }
    private void SetWindowned(bool isWindowned) 
    {
        settingsSO.WindowMode = isWindowned;
    }
    private void SetMasterVolume(float newMasterVolume)
    {
        settingsSO.MasterVolume = newMasterVolume;
    }
    private void SetOSTVolume(float newOSTVolume)
    {
        settingsSO.OSTVolume = newOSTVolume;
    }
    private void SetSFXVolume(float newSFXVolume)
    {
        settingsSO.SFXVolume = newSFXVolume;
    }
    private void SetVOVolume(float newVOVolume)
    {
        settingsSO.VOVolume = newVOVolume;
    }
    private void SaveButton()
    {
        settingsManager.SaveSettings();
        settingsSO.ApplySettings();
    }
    #endregion

    private void AddListeners() 
    {
        if(UIElementsValidation() == false) return;

        dResolutions.onValueChanged.AddListener(SetResolutionIndex);
        dFontSize.onValueChanged.AddListener(SetFontSize);
        tIsInteractable.onValueChanged.AddListener(SetInteractable);
        tIsWindowned.onValueChanged.AddListener(SetWindowned);
        sMasterVolume.onValueChanged.AddListener(SetMasterVolume);
        sOSTVolume.onValueChanged.AddListener(SetOSTVolume);
        sSFXVolume.onValueChanged.AddListener(SetSFXVolume);
        sVOVolume.onValueChanged.AddListener(SetVOVolume);
        saveButton.onClick.AddListener(SaveButton);
    }

    private void RemoveListeners()
    {
        if (dResolutions != null) dResolutions.onValueChanged.RemoveListener(SetResolutionIndex);
        if (dFontSize != null) dFontSize.onValueChanged.RemoveListener(SetFontSize);
        if (tIsInteractable != null) tIsInteractable.onValueChanged.RemoveListener(SetInteractable);
        if (tIsWindowned != null) tIsWindowned.onValueChanged.RemoveListener(SetWindowned);
        if (sMasterVolume != null) sMasterVolume.onValueChanged.RemoveListener(SetMasterVolume);
        if (sOSTVolume != null) sOSTVolume.onValueChanged.RemoveListener(SetOSTVolume);
        if (sSFXVolume != null) sSFXVolume.onValueChanged.RemoveListener(SetSFXVolume);
        if (sVOVolume != null) sVOVolume.onValueChanged.RemoveListener(SetVOVolume);
        if (saveButton != null) saveButton.onClick.RemoveListener(SaveButton);
    }

    private void UpdateUIBasedOnSettings() 
    {
        RemoveListeners(); //Evita problemas

        if (UIElementsValidation() == true) 
        {
             dResolutions.value = settingsSO.ResolutionIndex;
             dFontSize.value = settingsSO.FontSize;
             tIsInteractable.isOn = settingsSO.InteractionMode;
             tIsWindowned.isOn = settingsSO.WindowMode;
             sMasterVolume.value = settingsSO.MasterVolume;
             sOSTVolume.value = settingsSO.OSTVolume;
             sSFXVolume.value = settingsSO.SFXVolume;
             sVOVolume.value = settingsSO.VOVolume;
             Debug.Log("UI updated sucessfull");
        }
        else 
        {
            Debug.LogWarning("UI updated unsucessfull");
        }

        AddListeners();        
    }


    private void SettingsSavedFeedback()
    {
        Debug.Log("Settings saved successfully! (UI Feedback)");
    }

    private void populateDropdown<T>(List<T> list, TMP_Dropdown dropdown) 
    {
        List<string> options = list.Select(res => res.ToString()).ToList();
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }   

    private bool UIElementsValidation() 
    {
        foreach (Selectable aux in UIelements)
        {
            if (aux == null)
            {
                Debug.LogWarning($"Somenthing in {this.gameObject.name} is null, please fix");
                return false;
            }
        }
        return true;
    }
}
