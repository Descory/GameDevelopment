using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    Stats myStats;
    public AudioSource weapon;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<Stats>();
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat combat = playerManager.player.GetComponent<CharacterCombat>();
        if (combat != null)
        {
            combat.Attack(myStats, weapon);
        }
    }


}
