using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class BasketGame : FarmGame
{
    public GameObject farmerSprite;
    public GameObject basketSprite;
    public GameObject playerSpawn;
    public GameObject coop;

    private void Awake()
    {
        player = FindObjectOfType<NewPlayerController>().gameObject;
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

        yield return new WaitWhile(() => gameTimer > 0);

        ScoreGame();

        yield break;
    }
    public void SetUpGame()
    {
        CameraContoller.gameTransform = this.transform;
        CameraContoller.followingPlayer = false;
        gameTimer = initialGameTime;
        player.transform.position = new Vector3(playerSpawn.transform.position.x, playerSpawn.transform.position.y, -0.1f);
        player.transform.localScale = new Vector3(2, 2, 2);
        player.GetComponent<CapsuleCollider2D>().size = new Vector2(2, 2);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        farmerSprite.SetActive(false);
        basketSprite.SetActive(true);
        player.GetComponent<Rigidbody2D>().gravityScale = 20;
        coop.SetActive(true);
    }

    public override void ScoreGame()
    {
        CameraContoller.followingPlayer = true;
        player.transform.position = new Vector3(accessPoint.transform.position.x, accessPoint.transform.position.y, -0.1f);
        player.transform.localScale = new Vector3(1, 1, 1);
        player.GetComponent<CapsuleCollider2D>().size = new Vector2(1, 2);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        farmerSprite.SetActive(true);
        basketSprite.SetActive(false);
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        coop.SetActive(false);
        GameController.score += Score;
        Debug.Log($"Total: {GameController.score}");
    }
}