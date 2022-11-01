using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;



public class BasketGame : MonoBehaviour
{
    [SerializeField] private string ingredientType;
    private static PlayerData player { get; set; }
    private PlayerController playerController { get; set; }
    private int numCollected { get; set; }
    private bool isPlaying { get; set; }
    [SerializeField ]private float initialGameTime;
    private float gameTimer { get; set; }

    void Awake()
    {
        player = FindObjectOfType<PlayerData>();
        playerController = FindObjectOfType<PlayerController>();
        //player = controller.playerData;
        gameTimer = initialGameTime;
    }

    IEnumerator Play()
    {
        Ingredients ingredient = ToIngredient(ingredientType);
        Debug.Log("PLAYING");
        Debug.Log(isPlaying);

        yield return new WaitWhile(() => isPlaying);

        player.Inventory[(int)ingredient] += numCollected;
        Debug.Log("SCORING");
        Debug.Log(isPlaying);
        //PrintInventory();

        yield break;
    }

    private static Ingredients ToIngredient(string ingredientString)
    {
        return Enum.TryParse<Ingredients>(ingredientString, true, out Ingredients ingredient) ? ingredient : Ingredients.Unknown;
    }

    public void AddIngredient()
    {
        numCollected++;
    }

    public void PlayGame()
    {
        isPlaying = true;
        StartCoroutine(Play());
    }

    public void ScoreGame()
    {   
        isPlaying = false;
        gameTimer = initialGameTime;
    }

    private void PrintInventory()
    {
        for (int i = 0; i < player.Inventory.Length - 1; i++)
        {
            string name = Enum.GetName(typeof(Ingredients), i);
            Debug.Log($"{name}: {player.Inventory[i]}");
        }
    }
}
