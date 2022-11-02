using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class BasketGame : FarmGame
{
    public override event EventHandler<int> gameOutput;

    


    private void Awake()
    {
        player = FindObjectOfType<NewPlayerController>().gameObject;
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
    }

    public override IEnumerator Play()
    {
        SetUpGame();

        
        
        //Ingredients ingredient = ToIngredient(ingredientType);

        yield return new WaitWhile(() => gameTimer > 0);

        ScoreGame();

        yield break;
    }

    public override void ScoreGame()
    {
        gameOutput?.Invoke(this, Score);
    }

    public void SetUpGame()
    {
        gameTimer = initialGameTime;
        Vector2 playerPos = player.transform.position;
        playerPos = this.transform.position;
    }

    //private static Ingredients ToIngredient(string ingredientString)
    //{
    //    return Enum.TryParse<Ingredients>(ingredientString, true, out Ingredients ingredient) ? ingredient : Ingredients.Unknown;
    //}
}
