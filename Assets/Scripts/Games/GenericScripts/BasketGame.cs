using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;



public class BasketGame : FarmGame
{
    public override string ingredientType { get; set; }
    public override float initialGameTime { get; set; }
    public override float gameTimer { get; set; }
    public override int numCollected { get; set; }
    public override PlayerData player { get; set; }

    void Start()
    {
        player = FindObjectOfType<PlayerData>();
    }

    public override void PlayGame()
    {
        StartCoroutine(Play());
        gameTimer = initialGameTime;
    }

    public override IEnumerator Play()
    {
        Ingredients ingredient = ToIngredient(ingredientType);

        yield return new WaitWhile(() => gameTimer > 0);

        player.Inventory[(int)ingredient] += numCollected;

        yield break;
    }

    public void AddIngredient()
    {
        numCollected++;
    }

    public override void ScoreGame()
    {   
        gameTimer = initialGameTime;
    }
    private static Ingredients ToIngredient(string ingredientString)
    {
        return Enum.TryParse<Ingredients>(ingredientString, true, out Ingredients ingredient) ? ingredient : Ingredients.Unknown;
    }
}
