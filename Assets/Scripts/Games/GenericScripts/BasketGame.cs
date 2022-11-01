using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class BasketGame : FarmGame
{
    void Start()
    {
        player = FindObjectOfType<PlayerData>();
    }

    private void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }
        else
        {
            gameTimer = 0;
        }
    }

    public override void PlayGame()
    {
        StartCoroutine(Play());
        gameTimer = initialGameTime;
    }

    public override IEnumerator Play()
    {
        Debug.Log("is playing");
        Ingredients ingredient = ToIngredient(ingredientType);

        yield return new WaitWhile(() => gameTimer > 0);

        player.Inventory[(int)ingredient] += numCollected;

        player.Inventory[(int)ingredient] += numCollected;

        yield break;
    }

    public void AddIngredient()
    {
        numCollected++;
    }

    public override void AddToInventory()
    {
        
    }

    private static Ingredients ToIngredient(string ingredientString)
    {
        return Enum.TryParse<Ingredients>(ingredientString, true, out Ingredients ingredient) ? ingredient : Ingredients.Unknown;
    }
}
