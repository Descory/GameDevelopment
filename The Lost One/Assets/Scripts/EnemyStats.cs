using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    public Stats player;
    public int XPDrop;
    public AudioSource DyingSound;
    public override bool Damage(int dmg)
    {
        bool alive = base.Damage(dmg);
        if (!alive)
        {
            DyingSound.PlayOneShot(DyingSound.clip);
            player.AddXP(XPDrop);
            Destroy(this.gameObject);
            return false;
        }
        return true;
    }
}
