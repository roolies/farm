using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGame : FarmGame
{
    public GameObject playerSpawn;
    public GameObject spawners;

    public GameObject[] carrots = new GameObject[4];

    private void Awake()
    {
        player = FindObjectOfType<NewPlayerController>().gameObject;
        Score = 0;
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

        while(gameTimer > 0)
        {

        }

        yield return new WaitWhile(() => gameTimer > 0);

        ScoreGame();

        yield break;
    }
    public void SetUpGame()
    {
        CameraContoller.gameTransform = this.transform;
        CameraContoller.followingPlayer = false;
        player.GetComponent<NewPlayerController>().enabled = false;
        gameTimer = initialGameTime;
        player.transform.position = new Vector3(playerSpawn.transform.position.x, playerSpawn.transform.position.y, -0.1f);
        spawners.SetActive(true);
    }

    public override void ScoreGame()
    {
        CameraContoller.followingPlayer = true;
        player.GetComponent<NewPlayerController>().enabled = true;
        player.transform.position = new Vector3(accessPoint.transform.position.x, accessPoint.transform.position.y, -0.1f);
        //GameController.score += Score;
        Debug.Log($"Total: {GameController.score}");
        spawners.SetActive(false);
        Score = 0;
    }
}
