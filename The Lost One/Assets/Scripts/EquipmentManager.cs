using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currEquip;
    public Stats Player;
    Inventory inv;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;


    private void Start()
    {
        inv = Inventory.instance;
        int num = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currEquip = new Equipment[num];
    }

    public void Equip(Equipment newItem)
    {
        int index = (int)newItem.EquipSlot;

        Equipment lItem = null;

        if(currEquip[index] != null)
        {
            lItem = currEquip[index];
            inv.Add(lItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, lItem);
        }
        if(lItem == null)
        {
            Player.AttackDamage(newItem.damageValue, 0);
            Player.Protection(newItem.armorValue, 0);
        }
        else
        {
            Player.AttackDamage(newItem.damageValue, lItem.damageValue);
            Player.Protection(newItem.armorValue, lItem.armorValue);
        }
        
        currEquip[index] = newItem;
    }
}
