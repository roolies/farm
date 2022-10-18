using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace FarmGame
{
    internal class CollectionGame : MonoBehaviour
    {
        [SerializeField] private string ingredientType;
        public static GameController controller { get; private set; }
        private static PlayerData player { get; set; }
        private int numCollected { get; set; }
        private bool isPlaying { get; set; }

        [Header("Minigame UI")]
        [SerializeField] private GameObject gameUI;
        [SerializeField] private Text ingredientText;

        void Awake()
        {
            controller = GameObject.FindObjectOfType<GameController>();
            player = controller.playerData;
        }
        IEnumerator PlayMinigame()
        {
            Ingredients ingredient = ToIngredient(ingredientType);
            gameUI.SetActive(true);
            ingredientText.text = $"Collect the {ingredientType}!";
            Debug.Log(player.Inventory[(int)ingredient]);

            yield return new WaitWhile(() => isPlaying);

            player.Inventory[(int)ingredient] += numCollected;
            gameUI.SetActive(false);
            Debug.Log(player.Inventory[(int)ingredient]);

            yield break;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit");
                StartCoroutine(PlayMinigame());
            }
        }

        private static Ingredients ToIngredient(string ingredientString)
        {
            return Enum.TryParse<Ingredients>(ingredientString, true, out Ingredients ingredient) ? ingredient : Ingredients.unknown;
        }

        public void AddIngredient()
        {
            numCollected++;
        }

        public void EndMiniGame()
        {
            isPlaying = false;
        }
    }
}