using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Button defaultBtn, ctrlBackBtn, creditBackBtn;

    [SerializeField]
    private GameObject ctrlScreen, creditScreen;

    public MainMenu()
    {
        defaultBtn = null;
        ctrlBackBtn = null;
        creditBackBtn = null;

        ctrlScreen = null;
        creditScreen = null;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if(hasFocus)
        {
            defaultBtn.Select();
        }

    }

    void FixedUpdate()
    {
        if(creditScreen.activeInHierarchy)
        {
            creditBackBtn.Select();
        }
        else if(ctrlScreen.activeInHierarchy)
        {
            ctrlBackBtn.Select();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
