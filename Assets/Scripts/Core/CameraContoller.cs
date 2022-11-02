using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField] int playerCamSize;
    [SerializeField] int gameCamSize;

    private Transform playerTransform { get; set; }
    public static Transform gameTransform { get; set; }
    private Camera cam { get; set;}
    public static bool followingPlayer { get; set;}

    private void Start()
    {
        cam = GetComponent<Camera>();
        playerTransform = FindObjectOfType<NewPlayerController>().gameObject.transform;
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

    public void FocusOnPlayer()
    {
        this.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -35f);
        cam.orthographicSize = playerCamSize;
    }

    public void FocusOnGame()
    {
        this.transform.position = new Vector3(gameTransform.position.x, gameTransform.position.y, -35f);
        cam.orthographicSize = gameCamSize;
    }
}
