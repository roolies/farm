using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmController : MonoBehaviour
{
    private PlayerData PlayerData { get; set; }
    private GameObject Player { get; set; }
    private bool farmPhase { get; set; }
    public float timer { get; private set; }

    [SerializeField] private float timerStartValue;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject kitchenHUD;

    void Start()
    {
        farmPhase = true;
        timer = timerStartValue;
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerData = FindObjectOfType<PlayerData>();
    }

    void Update()
    {
        timerText.text = timer.ToString("F1");
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0 && farmPhase == true)
        {
            BeginCooking();
        }
        else
        {
            timer = 0;
        }
    }

    private void BeginCooking()
    {
        RemoveControl();
        farmPhase = false;
        timer = timerStartValue;
        kitchenHUD.SetActive(true);
    }

    void RemoveControl()
    {
        Player.GetComponent<NewPlayerController>().enabled = false;
    }
}
