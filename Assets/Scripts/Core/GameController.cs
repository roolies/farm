using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int score;
    public float timer { get; private set; }

    [SerializeField] private float timerStartValue;
    [SerializeField] private Text timerText;

    void Start()
    {
        timer = timerStartValue;
        
    }

    void Update()
    {
        timerText.text = timer.ToString("F1");
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        //SceneManager.LoadScene("WinScreen");
    }
}
