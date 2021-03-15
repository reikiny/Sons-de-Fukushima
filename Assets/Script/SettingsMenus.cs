using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
public class SettingsMenus : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Toggle fullScreen;

    public const string RESOLUTION_PREF_KEY = "resolution";
    public const string QUALITY_PREF_KEY = "quality";
    public const string FULLSCREEN_PREF_KEY = "fullscreen";
    public const string MUSIC_VOLUME_PREF_KEY = "music-volume";
    public const string VO_VOLUME_PREF_KEY = "voice-volume";

    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();

        for(int i =0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //prefs
        currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY,default);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(QUALITY_PREF_KEY,default));
        Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt(FULLSCREEN_PREF_KEY,0));
       
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        qualityDropdown.value = PlayerPrefs.GetInt(QUALITY_PREF_KEY,default);
        fullScreen.isOn = Convert.ToBoolean(PlayerPrefs.GetInt(FULLSCREEN_PREF_KEY,0));
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RESOLUTION_PREF_KEY, resolutionIndex);
    }
   public void SetVolume(float volume)
   {
       audioMixer.SetFloat("Volume", volume);
   }
   public void SetMusicVolume(float volume)
   {
        audioMixer.SetFloat("MusicVolume", volume);

   }
   public void SetEffectVolume(float volume)
   {
        audioMixer.SetFloat("EffectVolume", volume);

   }
   public void SetFalaVolume(float volume)
   {
        audioMixer.SetFloat("FalaVolume", volume);

   }

   public void SetQuality (int qualityIndex)
   {
       QualitySettings.SetQualityLevel(qualityIndex);
       PlayerPrefs.SetInt(QUALITY_PREF_KEY,qualityIndex);
      
   }

   public void SetFullscrenn (bool isFullscreen)
   {
       Screen.fullScreen = isFullscreen;
       PlayerPrefs.SetInt(FULLSCREEN_PREF_KEY, Convert.ToInt32(isFullscreen));

   }
}
