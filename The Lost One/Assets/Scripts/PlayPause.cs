using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }


    public void PlayeGame()
    {
        Time.timeScale = 1;
    }
}
