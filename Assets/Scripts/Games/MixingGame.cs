using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingGame : KitchenGame
{
    public override int Score { get; set; }

    public override event EventHandler<int> gameOutput;

    public override void PlayGame()
    {
        StartCoroutine(Play());
    }

    public override IEnumerator Play()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        Score = 10;

        ScoreGame();
        
        yield break;
    }

    public override void ScoreGame()
    {
        gameOutput?.Invoke(this, Score);
    }
}
