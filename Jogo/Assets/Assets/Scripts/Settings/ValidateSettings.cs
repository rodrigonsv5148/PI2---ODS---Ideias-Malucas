using FMOD.Studio;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ValidateSettings
{
    SettingsSO settings;

    public ValidateSettings(SettingsSO _settings) 
    {
        this.settings = _settings;
    }

    public bool validateSettings()
    {
        if (settings == null)
        {
            Debug.LogWarning($"Critical error, settings is not set in Validate Settings");
            return false;
        }

        if (settings.SFXVolume < settings.MinVolumeValue || settings.SFXVolume > settings.MaxVolumeValue)
        {
            Debug.LogWarning(   $"Not aceptable value for SFX Volume. " +
                                $"\nAcceptable Range: {settings.MinVolumeValue} - {settings.MaxVolumeValue}" +
                                $"\nValue received: {settings.SFXVolume}");
            return false;
        }

        if (settings.OSTVolume < settings.MinVolumeValue || settings.OSTVolume > settings.MaxVolumeValue)
        {
            Debug.LogWarning(   $"Not aceptable value for OST volume. " +
                                $"\nAcceptable Range: {settings.MinVolumeValue} - {settings.MaxVolumeValue}" +
                                $"\nValue received: {settings.OSTVolume}");
            return false;
        }

        if (settings.VOVolume < settings.MinVolumeValue || settings.VOVolume > settings.MaxVolumeValue)
        {
            Debug.LogWarning(   $"Not aceptable value for VO volume. " +
                                $"\nAcceptable Range: {settings.MinVolumeValue} - {settings.MaxVolumeValue}" +
                                $"\nValue received: {settings.VOVolume}");
            return false;
        }

        if (settings.MasterVolume < settings.MinVolumeValue || settings.MasterVolume > settings.MaxVolumeValue) 
        {
            Debug.LogWarning(   $"Not aceptable value for MASTER Volume." +
                                $"\nAcceptable range: {settings.MinVolumeValue} - {settings.MaxVolumeValue}" +
                                $"\nValue received: {settings.MasterVolume}");
            return false;
        }

        if (settings.FontSize < settings.MinFontSize || settings.FontSize > settings.MaxFontSize) // TODO: Balancear isso.
        {
            Debug.LogWarning(   $"Not aceptable value for font Size. " +
                                $"\nAcceptable Range: {settings.MinFontSize} - {settings.MaxFontSize}" +
                                $"\nValue received: {settings.FontSize}");
            return false;
        }

        int qteResolutions = settings.GetResolutions().Count - 1;

        if (settings.ResolutionIndex < 0 || settings.ResolutionIndex > qteResolutions) 
        {
            Debug.LogWarning(   $"Validation Error: Resolution index {settings.ResolutionIndex} is out of bounds." +
                                $"Max index is {qteResolutions - 1}.");

            return false;
        }

        if (DictionaryVCAValidation(settings.GetVCAsList()) == false) return false;
        
        Debug.Log("Validation Sucess, applying the values");
        return true;
    }

    public bool DictionaryVCAValidation (List<VCA> vcas) 
    {
        foreach (var vca in vcas)
        {
            if (vca.isValid() == false)
            {
                Debug.LogWarning($"Error in VCA dictionary on file {settings.name}");
                return false;
            }
        }

        return true;
    }
}

