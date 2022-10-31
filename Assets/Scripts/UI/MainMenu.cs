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
    private GameObject mainScreen, ctrlScreen, creditScreen;

    public MainMenu()
    {
        defaultBtn = null;
        ctrlBackBtn = null;
        creditBackBtn = null;
        
        mainScreen = null;
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

   public void SeeControls()
    {
        ctrlScreen.SetActive(true);
        ctrlBackBtn.Select();

        mainScreen.SetActive(false);
        creditScreen.SetActive(false);

    }
    public void SeeCredits()
    {
        creditScreen.SetActive(true);
        creditBackBtn.Select();

        mainScreen.SetActive(false);
        ctrlScreen.SetActive(false);

    }
    public void BackToMain()
    {
        mainScreen.SetActive(true);
        defaultBtn.Select();

        creditScreen.SetActive(false);
        ctrlScreen.SetActive(false);
    }
}
