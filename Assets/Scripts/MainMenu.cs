using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Button defaultBtn, ctrlBackBtn, creditBackBtn;

    public MainMenu()
    {
        defaultBtn = null;
        ctrlBackBtn = null;
        creditBackBtn = null;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if(hasFocus)
        {
            defaultBtn.Select();
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
