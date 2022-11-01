using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class AccessPoint : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private FarmGame game;

    private PlayerInput playerInput { get; set; }
    private bool CanPlay { get; set; }

    private void Awake()
    {
        CanPlay = false;

        playerInput = FindObjectOfType<PlayerInput>();

        playerInput.actions["Interact"].performed += context => StartGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            prompt.SetActive(true);
            promptText.text = $"Interact To Collect {game.ingredientType}!";
            CanPlay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            prompt.SetActive(false);
            CanPlay = false;
        }
    }

    public void StartGame()
    {
        if(CanPlay)
        {
            game.PlayGame();
        }
    }
}
