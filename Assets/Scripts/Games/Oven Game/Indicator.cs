using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
 
public class Indicator : MonoBehaviour
{
    public Vector3 pointB;
    private bool active = true;

    FarmerGame ovenControls;
    private InputAction stopIndicator;
    private InputAction exitOven;

    public TextMeshProUGUI result;
   
    IEnumerator Start()
    {
        transform.position = new Vector3(-8.0f, 1.5f, 0f);

        var pointA = transform.position;
        while (active)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.7f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 0.7f));
        }
    }

    public void Update()
    {
        if (exitOven.IsPressed())
        {
            SceneManager.LoadScene("MainScene");
        }

        if (active == false)
        {
            if (Math.Abs(transform.position.x) <= 0.5)
            {
                result.text = "Your dish is perfect!";
            }
            else if (Math.Abs(transform.position.x) <= 3.0)
            {
                result.text = "Your dish is slightly overcooked!";
            }
            else if (Math.Abs(transform.position.x) <= 8.0)
            {
                result.text = "Your dish is burnt!";
            }
        }
    }
   
    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f/time;
        while (i < 1.0f)
        {
            if (stopIndicator.IsPressed())
            {
                active = false;
                break;
            }

            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }

    private void OnEnable()
    {
        ovenControls = new FarmerGame();
        
        stopIndicator = ovenControls.Oven.StopIndicator;
        stopIndicator.Enable();

        exitOven = ovenControls.Oven.ExitOven;
        exitOven.Enable();
    }

    private void OnDisable()
    {
        stopIndicator.Disable();
        exitOven.Disable();
    }
}
