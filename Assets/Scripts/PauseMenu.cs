using UnityEngine;
using UnityEngine.InputSystem;
using FarmGame;

public class PauseMenu : MonoBehaviour
{
    private FamerGame playerInput;
    private bool isPaused = false;
    [SerializeField]
    private GameObject pauseMenuUI;

    void Awake()
    {
        playerInput = new FamerGame();

    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        if(playerInput.Player.PauseGame.triggered && !isPaused)
        {
            Debug.Log("Tried to pause game");
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
        }
        else if (playerInput.Player.PauseGame.triggered && isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }
    }
}
