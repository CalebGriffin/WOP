using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject quitCanvas;

    public GameObject quitCursor;

    public GameObject settingsCanvas;

    public GameObject settingsCursor;

    public GameObject controlsCanvas;

    public GameObject creditsCanvas;

    public GameObject uiController;

    public Slider volumeSlider;

    PlayerControls controls;

    // Awake is called even before Start
    void Awake()
    {
        // Creates a new instance of the player controls
        controls = new PlayerControls();

        controls.Menu.Up.performed += ctx => Up();
        controls.Menu.Down.performed += ctx => Down();
        controls.Menu.Left.performed += ctx => Left();
        controls.Menu.Right.performed += ctx => Right();
        controls.Menu.Confirm.performed += ctx => Confirm();
    }

    void Up()
    {
        if (quitCanvas.activeSelf)
        {
            if (quitCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(-175f, 50f))
            {
                quitCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(-175f, 150f);
            }
        }
        else if (settingsCanvas.activeSelf)
        {
            if (settingsCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(175f, -290f))
            {
                settingsCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(250f, -50f);
            }
        }
    }

    void Down()
    {
        if (quitCanvas.activeSelf)
        {
            if (quitCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(-175f, 150f))
            {
                quitCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(-175f, 50f);
            }
        }
        else if (settingsCanvas.activeSelf)
        {
            if (settingsCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(250f, -50f))
            {
                settingsCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(175f, -290f);
            }
        }
    }

    void Left()
    {
        if (settingsCanvas.activeSelf)
        {
            if (settingsCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(250f, -50f))
            {
                volumeSlider.value = volumeSlider.value - 0.1f;
            }
        }
    }

    void Right()
    {
        if (settingsCanvas.activeSelf)
        {
            if (settingsCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(250f, -50f))
            {
                volumeSlider.value = volumeSlider.value + 0.1f;
            }
        }
    }

    void Confirm()
    {
        if (quitCanvas.activeSelf)
        {
            if (quitCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(-175f, 150f))
            {
                Application.Quit();
            }
            else if (quitCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(-175f, 50f))
            {
                quitCanvas.SetActive(false);
                uiController.SetActive(false);
            }
        }
        else if (controlsCanvas.activeSelf)
        {
            controlsCanvas.SetActive(false);
            uiController.SetActive(false);
        }
        else if (creditsCanvas.activeSelf)
        {
            creditsCanvas.SetActive(false);
            uiController.SetActive(false);
        }
        else if (settingsCanvas.activeSelf)
        {
            if (settingsCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(175f, -290f))
            {
                settingsCanvas.SetActive(false);
                uiController.SetActive(false);
            }
        }
    }

    private void OnEnable() 
    {
        gVar.isPaused = true;
        controls.Menu.Enable();
    }

    private void OnDisable()
    {
        gVar.isPaused = false;
        controls.Menu.Disable();
    }
}
