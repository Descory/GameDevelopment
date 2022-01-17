using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wincondition : Interactable
{


    public GameObject GameOverScreen;
    public Stats stats;
    public Text GameOverXP;
    public GameObject[] buttons;
    public override void Interact()
    {
        base.Interact();
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
        int LifetimeXP = 0;
        for (int i = 0; i < stats.Level - 1; i++)
        {
            LifetimeXP += (i + 1) * 125;
        }
        LifetimeXP += stats.Experience;
        GameOverXP.text = LifetimeXP.ToString();
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        
    }
}
