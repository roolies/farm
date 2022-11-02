using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarmGame : MonoBehaviour
{
    public string ingredientType;

    public float initialGameTime;

    public GameObject player;
    public float gameTimer { get; set; }
    public int Score { get; set; }

    public abstract event EventHandler<int> gameOutput;

    public abstract void PlayGame();

    public abstract IEnumerator Play();

    public abstract void ScoreGame();
}
