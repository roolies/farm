using FarmGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenController : MonoBehaviour
{
    private List<KitchenGame> gamesToPlay { get; set; }

    private PlayerData playerData { get; set; } = FindObjectOfType<PlayerData>();

    private CameraContoller camController { get; set; } = FindObjectOfType<CameraContoller>();

    private int DishScore { get; set; }

    private int TotalScore { get; set; }

    private bool Ping { get; set; } = false;

    public GameObject currentScreen { get; set; }

    [SerializeField] GameObject kitchenHome;
    [SerializeField] GameObject recipeResult;
    [SerializeField] GameObject finalResult;
    
    public void CookRecipe(string input)
    {
        Recipes recipe = ToRecipe(input);
        switch(recipe)
        {
            case Recipes.PumpkinPie:
                break;
            case Recipes.MashedPotatoes:
                if(CanCook(Ingredients.Potatoes, 3))
                {
                    gamesToPlay.Add(FindObjectOfType<MixingGame>());
                }
                else
                {
                    Debug.Log("Not enough potatoes.");
                }
                break;
            case Recipes.RoastTurkey:
                break;
            default:
                Debug.Log("Unknown recipe");
                break;
        }

        if(gamesToPlay.Count > 0)
        {
            StartCoroutine(PlayGames());
        }
    }

    IEnumerator PlayGames()
    {
        kitchenHome.SetActive(false);
        foreach(KitchenGame game in gamesToPlay)
        {
            Ping = false;
            game.gameOutput += SendDishScore;
            camController.gameTransform = game.gameObject.transform;
            camController.FocusOnGame();
            game.PlayGame();
            yield return new WaitUntil(() => Ping);
        }
        AddToTotal();
        recipeResult.SetActive(true);
        currentScreen = recipeResult;
        yield return new WaitForSeconds(5f);
        if(IsGameOver())
        {
            GameOver();
        }
        else
        {
            ToHome();
        }
        gamesToPlay.Clear();
        yield break;
    }

    void SendDishScore(object sender, int score)
    {
        DishScore += score;
        Ping = true;
    }

    void AddToTotal()
    {
        TotalScore += DishScore;
        DishScore = 0;
    }

    void ToHome()
    {
        currentScreen.SetActive(false);
        kitchenHome.SetActive(true);
        currentScreen = kitchenHome;
    }

    bool CanCook(Ingredients ingredientNeeded, int amountNeeded)
    {
        bool result = false;
        int[] inventory = playerData.Inventory;
        for(int i = 0; i < inventory.Length; i++)
        {
            if(i == (int)ingredientNeeded && inventory[i] >= amountNeeded)
            {
                result = true;
                inventory[i] -= amountNeeded;
            }
        }
        return result;
    }

    bool IsGameOver()
    {
        bool result = true;
        int[] inventory = playerData.Inventory;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] >= 1)
            {
                result = false;
            }
        }
        return result;
    }

    void GameOver()
    {
        currentScreen.SetActive(false);
        finalResult.SetActive(true);
    }

    private static Recipes ToRecipe(string recipeString)
    {
        return Enum.TryParse<Recipes>(recipeString, true, out Recipes recipe) ? recipe : Recipes.Unknown;
    }
}
