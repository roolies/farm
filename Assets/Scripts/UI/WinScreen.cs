using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private Button defaultBtn;

    public WinScreen()
    {
        defaultBtn = null;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            defaultBtn.Select();
        }

    }
    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
