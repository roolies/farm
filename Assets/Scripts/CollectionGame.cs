using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace FarmGame
{
    public class CollectionGame : MonoBehaviour
    {
        [SerializeField] private string ingredientType;
        //public static GameController controller { get; private set; }
        private static PlayerData player { get; set; }
        private int numCollected { get; set; }
        private bool isPlaying { get; set; }
        [SerializeField ]private float initialGameTime;
        private float gameTimer { get; set; }

        //[Header("Minigame UI")]
        //[SerializeField] private GameObject gameUI;
        //[SerializeField] private Text ingredientText;

        void Awake()
        {
            player = FindObjectOfType<PlayerData>();
            //player = controller.playerData;
            gameTimer = initialGameTime;
        }

        private void Update()
        {
            if(isPlaying == true)
            {
                gameTimer -= Time.deltaTime;
                if(gameTimer <= 0)
                {
                    EndMiniGame();
                }
            }
        }

        IEnumerator PlayMinigame()
        {
            Ingredients ingredient = ToIngredient(ingredientType);
            //gameUI.SetActive(true);
            //ingredientText.text = $"Collect the {ingredientType}!";
            Debug.Log("PLAYING");
            Debug.Log(isPlaying);

            yield return new WaitWhile(() => isPlaying);

            player.Inventory[(int)ingredient] += numCollected;
            // gameUI.SetActive(false);
            Debug.Log("SCORING");
            Debug.Log(isPlaying);
            PrintInventory();

            yield break;
        }

        private static Ingredients ToIngredient(string ingredientString)
        {
            return Enum.TryParse<Ingredients>(ingredientString, true, out Ingredients ingredient) ? ingredient : Ingredients.unknown;
        }

        public void AddIngredient()
        {
            numCollected++;
        }

        public void StartMiniGame()
        {
            Debug.Log("HIT");
            isPlaying = true;
            StartCoroutine(PlayMinigame());
        }

        public void EndMiniGame()
        {
            Debug.Log("ENDED");
            isPlaying = false;
            gameTimer = initialGameTime;
        }

        private void PrintInventory()
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                string name = Enum.GetName(typeof(Ingredients), i);
                Debug.Log($"{name}: {player.Inventory[i]}");
            }
        }
    }
}