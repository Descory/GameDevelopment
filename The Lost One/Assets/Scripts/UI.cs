using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Stats stats;
    public Text crystals;
    public int cry;
    public Text health;
    public Text xpText;
    public Text currLvl;
    public Text message;
    public int AddHealth;
    public Slider healthSlider;
    public Slider xpSlider;
    public GameObject[] buttons;
    public GameObject GameOverScreen;
    public GameObject InventoryScreen;
    public Text GameOverXP;
    private AudioSource[] allAudioSources;
    public AudioSource Dying;
    public Button IncreaseStrenght;
    public Button IncreaseAgility;
    public Button IncreaseVitality;
    public Button IncreaseStealth;
    public Button Inventory;
    public Text Str;
    public Text Agl;
    public Text Vit;
    public Text Stl;
    public Text Lvl;
    public Text Atr;
    public Text AtrPt;
    public GameObject BloodPostProcess;

    private bool dead;

    //Updates crystal ammount and siplays message about picked up crystal
    public void UpdateCrystals(int crystal)
    {
        cry += crystal;
        stats.Heal(AddHealth);
        stats.AddXP(10);
        crystals.text = "Crystals:" + cry;
        StartCoroutine(RemoveText(5));
    }

    //Removes the received damge from health
    public void Damage(int dmg)
    {
        bool alive = stats.Damage(dmg);
        
    }
    void Start()
    {
        dead = false;
        cry = 0;
        healthSlider.maxValue = ((int)(stats.Vitality * 25 + stats.BaseHP));
        healthSlider.value = stats.Health;
        crystals.text = "Crystals:" + cry;
        xpText.text = "XP:" + stats.Experience + " / " + (stats.Level * 125);
        currLvl.text = "Lvl. "+ stats.Level;
        xpSlider.maxValue = (stats.Level * 125);
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audio in allAudioSources)
        {
            audio.Stop();
        }
        Inventory.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
        if (Input.GetKeyDown("t"))
        {
            stats.AddXP(stats.Level * 125);
        }

        health.text = "HP: " + stats.Health + " / " + ((int)(stats.BaseHP + stats.Vitality * 25));
        healthSlider.value = stats.Health;
        healthSlider.maxValue = ((int)(stats.Vitality * 25 + stats.BaseHP));
        xpText.text = "XP: " + stats.Experience + " / " + (stats.Level * 125);
        currLvl.text = "Lvl. " + stats.Level;
        xpSlider.value = stats.Experience;
        xpSlider.maxValue = stats.Level * 125;
        if (Inventory.IsActive())
        {
            if (stats.Points > 0)
            {
                IncreaseStrenght.gameObject.SetActive(true);
                IncreaseStealth.gameObject.SetActive(true);
                IncreaseVitality.gameObject.SetActive(true);
                IncreaseAgility.gameObject.SetActive(true);
                Atr.gameObject.SetActive(true);
                AtrPt.gameObject.SetActive(true);
                AtrPt.text = stats.Points.ToString();
            }
            else
            {
                IncreaseStrenght.gameObject.SetActive(false);
                IncreaseStealth.gameObject.SetActive(false);
                IncreaseVitality.gameObject.SetActive(false);
                IncreaseAgility.gameObject.SetActive(false);
                Atr.gameObject.SetActive(false);
                AtrPt.gameObject.SetActive(false);
            }
            Str.text = stats.Strenght.ToString();
            Agl.text = stats.Agility.ToString();
            Vit.text = stats.Vitality.ToString();
            Stl.text = stats.Stealth.ToString();
            Lvl.text = stats.Level.ToString();
        }
        if(stats.Health <= 40)
        {
            BloodPostProcess.SetActive(true);
        }
        else
        {
            BloodPostProcess.SetActive(false);
        }

        if (stats.Health == 0)
        {
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
            if (!dead)
            {
                Dying.PlayOneShot(Dying.clip);
                dead = true;
            }

        }
    }
    IEnumerator RemoveText(float s)
    {
        yield return new WaitForSeconds(s);
        message.text = "";
    }

}
