using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarmGame : MonoBehaviour
{
    public abstract string ingredientType { get; set; }
    public abstract float initialGameTime { get; set; }
    public abstract float gameTimer { get; set; }
    public abstract int numCollected { get; set; }
    public abstract PlayerData player { get; set; }

    public abstract void PlayGame();

    public abstract IEnumerator Play();

    public abstract void ScoreGame();
}
