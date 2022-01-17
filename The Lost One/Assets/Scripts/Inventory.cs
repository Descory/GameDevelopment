using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

        public static Inventory instance;

        private void Awake()
        {
            instance = this;
        }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public GameObject axe;
    public GameObject torch;

    public List<Item> items = new List<Item>();

    public int space = 20;


    public bool Add (Item item)
    {
        if(!item.isDefaultItem)
        { 
            if (items.Count >= space)
            {
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }

        }
        return true;
    }

    public void Remmove (Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }


}
