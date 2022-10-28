using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField] int playerCamSize;
    [SerializeField] int gameCamSize;

    private Transform playerTransform { get; set; }
    public Transform gameTransform { get; set; }
    private Camera camera { get; set;}
    private bool followingPlayer { get; set;}

    private void Start()
    {
        camera = GetComponent<Camera>();
        playerTransform = FindObjectOfType<PlayerController>().gameObject.transform;
        followingPlayer = true;
    }

    private void LateUpdate()
    {
        if(followingPlayer)
        {
            FocusOnPlayer();
        }
        else
        {
            FocusOnGame();
        }
    }

    private void FocusOnPlayer()
    {
        this.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -2f);
        camera.orthographicSize = playerCamSize;
    }

    private void FocusOnGame()
    {
        this.transform.position = new Vector3(gameTransform.position.x, gameTransform.position.y, -2f);
        camera.orthographicSize = gameCamSize;
    }
}
