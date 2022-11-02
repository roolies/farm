using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KitchenController : MonoBehaviour
{
    private List<KitchenGame> GamesToPlay { get; set; }

    private PlayerData PlayerData { get; set; }

    private CameraContoller CamController { get; set; }

    private FarmController FarmController { get; set; }

    private int DishScore { get; set; }

    private int TotalScore { get; set; }

    private bool Ping { get; set; } = false;

    public GameObject currentScreen { get; set; }

    [SerializeField] GameObject kitchenHome;
    [SerializeField] GameObject recipeResult;
    [SerializeField] GameObject finalResult;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Text inventoryText;

    private void Start()
    {
        GamesToPlay = new List<KitchenGame>();
        PlayerData = FindObjectOfType<PlayerData>();
        CamController = FindObjectOfType<CameraContoller>();
        FarmController = FindObjectOfType<FarmController>();
        PlayerData.Inventory[(int)Ingredients.Potatoes] = 6;
    }

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
                    GamesToPlay.Add(FindObjectOfType<MixingGame>());
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

        if(GamesToPlay.Count > 0)
        {
            StartCoroutine(PlayGames());
        }
    }

    IEnumerator PlayGames()
    {
        kitchenHome.SetActive(false);
        foreach(KitchenGame game in GamesToPlay)
        {
            Ping = false;
            game.gameOutput += AddDishScore;
            //CamController.gameTransform = game.gameObject.transform;
            //CamController.followingPlayer = false;
            game.PlayGame();
            yield return new WaitUntil(() => Ping);
            game.gameOutput -= AddDishScore;
        }
        AddToTotal();
        recipeResult.SetActive(true);
        currentScreen = recipeResult;
        yield return new WaitForSeconds(5f);
        if(IsGameOver() || FarmController.timer <= 0)
        {
            GameOver();
        }
        else
        {
            ToHome();
            inventoryText.text = PlayerData.ListInventory();
        }
        GamesToPlay.Clear();
        yield break;
    }

    void AddDishScore(object sender, int score)
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
        var inventory = PlayerData.Inventory;
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
        int[] inventory = PlayerData.Inventory;
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
        scoreText.text = $"Score: {TotalScore}";
    }

    private static Recipes ToRecipe(string recipeString)
    {
        return Enum.TryParse<Recipes>(recipeString, true, out Recipes recipe) ? recipe : Recipes.Unknown;
    }
}
