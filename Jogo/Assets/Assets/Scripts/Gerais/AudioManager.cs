using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider VolumeSlider;

    public void changeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
    }
}
