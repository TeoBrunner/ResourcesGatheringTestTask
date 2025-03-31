using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<ItemType, int> inventory = new();

    public event Action inventoryChanged;
        

    public void AddItem(ItemType item, int amount)
    {
        if(inventory.ContainsKey(item))
        {
            inventory[item] += amount;
        }
        else
        {
            inventory.Add(item, amount);
        }

        inventoryChanged?.Invoke();
    }

    private void DebugLogInventory()
    {
        string resultLog = "";
        foreach (var key in inventory.Keys)
        {
            resultLog += $"{key}:{inventory[key]}  ";
        }
        if(!string.IsNullOrEmpty(resultLog))
        {
            Debug.Log(resultLog);
        }
    }
}
