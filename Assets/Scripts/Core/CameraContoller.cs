using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] int playerCamSize;

    private Camera camera { get; set;}
    private bool followingPlayer { get; set;}

    private void Start()
    {
        camera = GetComponent<Camera>();
        followingPlayer = true;
    }

    private void LateUpdate()
    {
        if(followingPlayer)
        {
            this.transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, -2f);
            camera.orthographicSize = playerCamSize;
        }
    }
}
