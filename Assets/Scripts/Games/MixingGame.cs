using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingGame : KitchenGame
{
    public override event EventHandler<int> gameOutput;

    KitchenController controller { get; set; }

    private void Start()
    {
        controller = FindObjectOfType<KitchenController>();
    }

    public override void PlayGame()
    {
        StartCoroutine(Play());
    }

    public override IEnumerator Play()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        ScoreGame();
        
        yield break;
    }

    public override void ScoreGame()
    {
        gameOutput?.Invoke(this, 10);
    }
}
