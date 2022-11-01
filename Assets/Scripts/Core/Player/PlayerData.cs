using System;
using System.Collections.Generic;
using UnityEngine;



public class PlayerData : MonoBehaviour
{
    public int[] Inventory { get; set; } = new int[Enum.GetNames(typeof(Ingredients)).Length];

    public string ListInventory()
    {
        string iList = "";

        for (int i = 0; i < Inventory.Length - 1; i++)
        {
            string name = Enum.GetName(typeof(Ingredients), i);
            iList += $"{name}: {Inventory[i]}\n";
        }

        return iList;
    }
}