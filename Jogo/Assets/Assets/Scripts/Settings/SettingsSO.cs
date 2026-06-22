using UnityEngine;
using FMOD.Studio;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "Settings", menuName ="ScriptableObjects/Settings")]
public class SettingsSO : ScriptableObject
{
    /*[SerializeField] private ValidateSettings validateSettings;
    public ValidateSettings ValidateSettings 
    {
        get { return validateSettings; }
    }*/

    #region Screen Settings
    [SerializeField]
    //[HideInInspector]
    private bool windowMode;
    public bool WindowMode 
    {
        get { return windowMode; }
        set { windowMode = value; }
    }

    [System.NonSerialized]    
    //[HideInInspector]
    private List<Resolution> resolutions = new List<Resolution>
    {
        new Resolution(800,600),
        new Resolution(1280,720),
        new Resolution(1920,1080),
        new Resolution(2560,1440)
    };

    [SerializeField]
    //[HideInInspector]
    private int resolutionIndex;
    public int ResolutionIndex 
    {
        get { return resolutionIndex; }
        set { resolutionIndex = (int)Mathf.Clamp(value, 0f, resolutions.Count() - 1);}
    }
    #endregion

    #region Volume Settings
    [SerializeField]
    //[HideInInspector]
    private float sfxVolume;
    public float SFXVolume 
    {
        get { return sfxVolume; }
        set { sfxVolume = Mathf.Clamp01(value); }
    }

    [SerializeField]
    //[HideInInspector]
    private float ostVolume;
    public float OSTVolume 
    {
        get { return ostVolume; }
        set { ostVolume = Mathf.Clamp01(value); }
    }

    [SerializeField]
    //[HideInInspector]
    private float voVolume;
    public float VOVolume
    {
        get { return voVolume; }
        set { voVolume = Mathf.Clamp01(value); }
    }

    [SerializeField]
    //[HideInInspector]
    private float masterVolume;
    public float MasterVolume 
    {
        get { return masterVolume; }
        set { masterVolume = Mathf.Clamp01(value); }
    }

    private const float minVolumeValue = 0.0f;
    public float MinVolumeValue
    {
        get { return minVolumeValue; }
    }

    private const float maxVolumeValue = 1.0f;
    public float MaxVolumeValue
    {
        get { return maxVolumeValue; }
    }
    #endregion

    #region Other Settings
    [SerializeField]
    //[HideInInspector]
    private bool interactionMode; //habilita som ao passar o mouse por cima dos elementos interativos
    public bool InteractionMode
    {
        get { return interactionMode; }
        set { interactionMode = value; }
    }

    [SerializeField]
    //[HideInInspector]
    private int fontSize;
    public int FontSize
    {
        get { return fontSize; }
        set { fontSize = Mathf.Clamp(value, minFontSize, maxFontSize); }
    }

    private const int minFontSize = 24;
    public int MinFontSize
    {
        get { return minFontSize; }
    }

    private const int maxFontSize = 60;
    public int MaxFontSize
    {
        get { return maxFontSize; }
    }

    [SerializeField]
    private const int incrementFontSize = 9;
    public int IncrementFontSize
    {
        get { return incrementFontSize; }
    }
    #endregion

    #region FMOD Things
    //--------------------------------------------------- Fiz um "armengue" na nomeclatura das chaves do dicionario, se der problema, buscar aqui
    [System.NonSerialized]
    private Dictionary<string, VCA> vcas;

    /*private VCA 

    private VCA vcaOST = FMODUnity.RuntimeManager.GetVCA(FMOD_Names.VCA.ost);
    
    private VCA vcaSFX = FMODUnity.RuntimeManager.GetVCA(FMOD_Names.VCA.sfx);
    
    private VCA vcaVO = FMODUnity.RuntimeManager.GetVCA(FMOD_Names.VCA.vo);*/

    #endregion

    public void DefaultSettings() 
    {
        WindowMode = false;
        ResolutionIndex = 1;
        SFXVolume = 0.75f;
        OSTVolume = 0.75f;
        VOVolume = 0.75f;
        MasterVolume = 0.75f;
        InteractionMode = false;
        FontSize = 24;
    }

    public void ApplySettings() 
    {
        // Aplicando a validação
        if (new ValidateSettings(this).validateSettings()) return;

        ApplyScreenSettings();

        ApplySoundSettings();
    }

    #region Settings
    private void ApplyScreenSettings()
    {
        Debug.Log($"ResolutionIndex: {ResolutionIndex}");
        Debug.Log($"Resolutions Count: {resolutions?.Count}");
        Resolution selectedResolution = resolutions[ResolutionIndex];

        FullScreenMode isFullScreen = WindowMode ? FullScreenMode.Windowed : FullScreenMode.MaximizedWindow;

        // --------- Resolução e tela cheia
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, isFullScreen);
    }

    private void ApplySoundSettings()
    {
        if(new ValidateSettings(this).DictionaryVCAValidation(vcas) == false) GetVCAReferences();

        vcas[FMOD_Names.VCA.master].setVolume(MasterVolume);

        vcas[FMOD_Names.VCA.ost].setVolume(OSTVolume);

        vcas[FMOD_Names.VCA.sfx].setVolume(SFXVolume);

        vcas[FMOD_Names.VCA.vo].setVolume(VOVolume);
    }
    #endregion

    private void GetVCAReferences()
    {
        vcas = new Dictionary<string, VCA>
        {
            {FMOD_Names.VCA.master, FMODUnity.RuntimeManager.GetVCA(FMOD_Names.VCA.master) },
            {FMOD_Names.VCA.ost, FMODUnity.RuntimeManager.GetVCA(FMOD_Names.VCA.ost) },
            {FMOD_Names.VCA.sfx, FMODUnity.RuntimeManager.GetVCA(FMOD_Names.VCA.sfx) },
            {FMOD_Names.VCA.vo, FMODUnity.RuntimeManager.GetVCA(FMOD_Names.VCA.vo) }
        };
    }

    #region Functions
    public Dictionary<string, VCA> GetVCAsList() 
    {
        if (vcas == null)
        {
            GetVCAReferences();
        }

        foreach (var vca in vcas) 
        {
            if (vca.Value.isValid() == false) 
            {
                Debug.LogWarning($"Invalid VCA on {this.name}");
                return null;
            }
        }
        return vcas;
    
    }

    public List<Resolution> GetResolutions() 
    {
        return resolutions;
    }
    #endregion
}
