using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int BaseHP;
    public int Strenght;
    public int Agility;
    public int Vitality;
    public int Stealth;
    public int Points;
    public int Health;
    public int Experience;
    public int Level;
    public int dealDamage = 0;
    public int protectDamage = 0;
    public event System.Action OnDamage;
    public AudioSource DamageTakeSound;


    private void Start()
    {
        Health = (int)(BaseHP + Vitality * 25);
        Level = 1;
        Experience = 0;
    }


    public void Protection(int add, int subtract)
    {
        protectDamage += add - subtract;
    }

    public void AttackDamage(int add, int subtract)
    {
        dealDamage += add - subtract;
    }

    public void AddXP(int xp)
    {
        Experience += xp;
        CheckLvlUp();
    }

    public void Heal(int hp)
    {
        if (Health + hp > BaseHP + Vitality * 25)
        {
            Health = (int)(BaseHP + Vitality * 25);
        }
        else
        {
            Health += hp;
        }
    }

    public virtual bool Damage(int hp)
    {
        Health -= Mathf.Clamp(hp - protectDamage,0,int.MaxValue);
        DamageTakeSound.PlayOneShot(DamageTakeSound.clip);
        if (Health <= 0)
        {
            Health = 0;
            return false;
        }
        else
        {
            if (OnDamage != null)
            {
                OnDamage();   
            }
            return true;
        }
    }

    private void CheckLvlUp()
    {
        if (Experience >= Level * 125)
        {
            Experience -= Level * 125;
            Level += 1;
            Points += 3;
            Health = (int)(BaseHP + Vitality * 25);
        }
    }
    public void IncreaseStrenght()
    {
        Points -= 1;
        Strenght += 1;
    }
    public void IncreaseAgility()
    {
        Points -= 1;
        Agility += 1;
    }
    public void IncreaseVitality()
    {
        Points -= 1;
        Vitality += 1;
        Heal(25);
    }
    public void IncreaseStealth()
    {
        Points -= 1;
        Stealth += 1;
    }
}
