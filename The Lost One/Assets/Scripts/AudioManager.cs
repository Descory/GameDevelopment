using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SFXPref = "SFXPref";
    private int firstPlayIn;
    public AudioSource[] gameMusic;
    public AudioSource[] soundeffects;

    public Slider musicSlider, sfxSlider;
    private float music, sfx;
    void Start()
    {
        firstPlayIn = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayIn == 0)
        {
            music = 0.1f;
            sfx = 08f;
            musicSlider.value = music;
            sfxSlider.value = sfx;
            PlayerPrefs.SetFloat(MusicPref, music);
            PlayerPrefs.SetFloat(SFXPref, sfx);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            music = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = music;
            sfx = PlayerPrefs.GetFloat(SFXPref);
            sfxSlider.value = sfx;
        }

    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SFXPref, sfxSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSettings();
        }
    }

    public void UpdateSound()
    {
        for(int i = 0; i < gameMusic.Length; i++)
        {
            gameMusic[i].volume = musicSlider.value;
        }
        for(int y = 0; y < soundeffects.Length; y++)
        {
            soundeffects[y].volume = sfxSlider.value;
        }
    }

}
