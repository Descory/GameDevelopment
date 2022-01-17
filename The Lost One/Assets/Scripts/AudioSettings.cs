using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SFXPref = "SFXPref";
    public AudioSource[] gameMusic;
    public AudioSource[] soundeffects;
    private float music, sfx;
    private void Awake()
    {
        ContnueSettings();
    }

    private void ContnueSettings()
    {
        music = PlayerPrefs.GetFloat(MusicPref);
        sfx = PlayerPrefs.GetFloat(SFXPref);


        for (int i = 0; i < gameMusic.Length; i++)
        {
            gameMusic[i].volume = music;
        }
        for (int y = 0; y < soundeffects.Length; y++)
        {
            soundeffects[y].volume = sfx;
        }
    }
}
