using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarmGame : MonoBehaviour
{
    public string ingredientType;
    public float initialGameTime;
    public float gameTimer { get; set; }
    public int numCollected { get; set; }
    public PlayerData player { get; set; }

    public abstract void PlayGame();

    public abstract IEnumerator Play();

    public abstract void AddToInventory();
}
