using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class CharacterCombat : MonoBehaviour
{
    private float cooldown = 0f;
    Stats myStats;
    const float outCommbatTime = 2;
    float lastAttack;

    public event System.Action OnAttack;

    public bool InCombat { get; private set; }

    private void Start()
    {
        myStats = GetComponent<Stats>();    }
    public void Attack(Stats targetStats, AudioSource audio)
    {
        if (cooldown <= 0f)
        {
            if (OnAttack != null)
            {
                OnAttack();
            }
            Debug.Log((int)((myStats.Strenght * 0.1f + 1) * myStats.dealDamage));
            Debug.Log(audio);
            targetStats.Damage((int)((myStats.Strenght * 0.1f + 1) * myStats.dealDamage));
            cooldown = 1f / (myStats.Agility * 0.5f);
            InCombat = true;
            lastAttack = Time.time;
            audio.PlayOneShot(audio.clip);
        }

    }
    private void Update()
    {
        cooldown -= Time.deltaTime;
        if(Time.time - lastAttack > outCommbatTime)
        {
            InCombat = false;
        }
    }
}
