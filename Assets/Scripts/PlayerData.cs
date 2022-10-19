using System;
using System.Collections.Generic;
using UnityEngine;

namespace FarmGame
{
    public class PlayerData : MonoBehaviour
    {
        public int Score { get; set; } = 0;

        public int[] Inventory { get; set; } = new int[Enum.GetNames(typeof(Ingredients)).Length];
    }
}
