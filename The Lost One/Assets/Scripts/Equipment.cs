using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot EquipSlot;
    public int armorValue;
    public int damageValue;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        if (this.name == "Axe")
        {
            Inventory.instance.axe.SetActive(true);
        }
        else if (this.name == "Torch")
        {
            Inventory.instance.torch.SetActive(true);
        }
        
        RemoveFromInf();
    }

}


public enum EquipmentSlot { Head, Body, LeftHand, RightHand}