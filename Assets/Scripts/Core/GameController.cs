using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FarmGame
{
    public class GameController : MonoBehaviour
    {
        private PlayerData PlayerData { get; set; }
        private GameObject Player { get; set; }
        private bool farmPhase { get; set; }
        private bool cookingPhase { get; set; }
        private float timer { get; set; }

        [SerializeField] private float timerStartValue;
        [SerializeField] private Text timerText;
        [SerializeField] public Text inventoryText;
        [SerializeField] private GameObject kitchenHUD;

        void Start()
        {
            farmPhase = true;
            cookingPhase = false;
            timer = timerStartValue;
            Player = GameObject.FindGameObjectWithTag("Player");
            PlayerData = FindObjectOfType<PlayerData>();
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
            RemoveControl();
            farmPhase = !farmPhase;
            cookingPhase = !cookingPhase;
            timer = timerStartValue;
            kitchenHUD.SetActive(true);
            inventoryText.text = ListInventory();
        }

        void RemoveControl()
        {
            Player.GetComponent<PlayerController>().enabled = false;
        }

        public string ListInventory()
        {
            string iList = "";

            for (int i = 0; i < PlayerData.Inventory.Length - 1; i++)
            {
                string name = Enum.GetName(typeof(Ingredients), i);
                iList += $"{name}: {PlayerData.Inventory[i]}\n";
            }

            return iList;
        }
    }
}
