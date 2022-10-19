using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FarmGame
{
    public class GameController : MonoBehaviour
    {
        private GameObject player { get; set; }
        private GameObject kitchenSpawn { get; set; }
        private bool farmPhase { get; set; }
        private bool cookingPhase { get; set; }
        private float timer { get; set; }

        [SerializeField] private float timerStartValue;
        [SerializeField] private Text timerText;

        void Start()
        {
            farmPhase = true;
            cookingPhase = false;
            timer = timerStartValue;
            player = GameObject.FindGameObjectWithTag("Player");
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
                farmPhase = !farmPhase;
                cookingPhase = !cookingPhase;
                player.transform.position = kitchenSpawn.transform.position;
                timer = timerStartValue;
            }
            else
            {
                timer = 0;
            }
        }
    }
}
