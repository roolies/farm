using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator player;

    [SerializeField]
    GameObject playerController;
    Vector2 _moveInput;
    Vector2 direction;

    void Awake()
    {
        player = GetComponent<Animator>();
        _moveInput = playerController.GetComponent<PlayerController>().moveInput;
    }

    void Update()
    {
        _moveInput = playerController.GetComponent<PlayerController>().moveInput;

        CheckDirection();

        player.SetFloat("AnimY", _moveInput.y);
        player.SetFloat("AnimX", _moveInput.x);
        player.SetFloat("Speed", _moveInput.magnitude);
        


    }

    void CheckDirection()
    {
        direction = _moveInput;

        if(direction.x > 0)
        {
            player.SetFloat("FaceX", 1);
            player.SetFloat("FaceY", 0);
        }
        if(direction.x < 0)
        {
            player.SetFloat("FaceX", -1);
            player.SetFloat("FaceY", 0);
        }
        if(direction.y < 0)
        {
            player.SetFloat("FaceY", -1);
            player.SetFloat("FaceX", 0);
        }
        if(direction.y > 0)
        {
            player.SetFloat("FaceY", 1);
            player.SetFloat("FaceX", 0);
        }

    }
}
