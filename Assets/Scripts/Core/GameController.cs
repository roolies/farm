using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FarmGame
{
    public class GameController : MonoBehaviour
    {
        private PlayerData playerData { get; set; }
        private GameObject player { get; set; }
        private bool farmPhase { get; set; }
        private bool cookingPhase { get; set; }
        private float timer { get; set; }

        [SerializeField] private float timerStartValue;
        [SerializeField] private Text timerText;
        [SerializeField] private Text inventoryText;
        [SerializeField] private GameObject kitchenHUD;

        void Start()
        {
            farmPhase = true;
            cookingPhase = false;
            timer = timerStartValue;
            player = GameObject.FindGameObjectWithTag("Player");
            playerData = FindObjectOfType<PlayerData>();
            kitchenSpawn = GameObject.FindGameObjectWithTag("KitchenSpawn");
        }

        void Update()
        {
            timerText.text = timer.ToString("F1");
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else if(timer <= 0 && farmPhase == true)
            {
                BeginCooking();
            }
            else
            {
                timer = 0;
            }
        }

        private void BeginCooking()
        {
            farmPhase = !farmPhase;
            cookingPhase = !cookingPhase;
            timer = timerStartValue;
            kitchenHUD.SetActive(true);
            inventoryText.text = ListInventory();
        }

        private string ListInventory()
        {
            string iList = "";

            for (int i = 0; i < playerData.Inventory.Length - 1; i++)
            {
                string name = Enum.GetName(typeof(Ingredients), i);
                iList += $"{name}: {playerData.Inventory[i]}\n";
            }

            return iList;
        }
    }
}
