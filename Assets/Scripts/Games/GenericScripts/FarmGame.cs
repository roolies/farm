using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarmGame : MonoBehaviour
{
    public string ingredientType;

    public float initialGameTime;

    public GameObject player;
    public GameObject accessPoint;

    public float gameTimer { get; set; }
    public int Score;

    public abstract void PlayGame();

    public abstract IEnumerator Play();

    public abstract void ScoreGame();
}
