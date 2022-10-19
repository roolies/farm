using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmGame
{
    public class GameController : MonoBehaviour
    {
        public PlayerData playerData { get; private set; }

        private bool farmPhase { get; set; }
        private bool cookingPhase { get; set; }
        private float timer { get; set; }

        [SerializeField] private float timerStartValue;

        void Start()
        {
            farmPhase = true;
            cookingPhase = false;
            timer = timerStartValue;
            playerData = FindObjectOfType<PlayerData>();
            //StartCoroutine(GameLoop());
        }

        void Update()
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                farmPhase = !farmPhase;
                cookingPhase = !cookingPhase;
                timer = timerStartValue;
            }
        }

        IEnumerator GameLoop()
        {
            while(farmPhase == true)
            {

            }

            while(cookingPhase == true)
            {

            }

            yield break;
        }
    }
}
