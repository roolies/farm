using FarmGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{
    private List<KitchenGame> gamesToPlay { get; set; }
    
    public void CookRecipe(string input)
    {
        Recipes recipe = ToRecipe(input);
        switch(recipe)
        {
            case Recipes.PumpkinPie:
                break;
            case Recipes.MashedPotatoes:
                gamesToPlay.Add(FindObjectOfType<MixingGame>());
                break;
            case Recipes.RoastTurkey:
                break;
            default:
                Debug.Log("Unknown recipe");
                break;
        }

        StartCoroutine(PlayGames());
    }

    IEnumerator PlayGames()
    {
        yield break;
    }

    private static Recipes ToRecipe(string recipeString)
    {
        return Enum.TryParse<Recipes>(recipeString, true, out Recipes recipe) ? recipe : Recipes.Unknown;
    }
}
