using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject quitCanvas;

    public GameObject quitCursor;

    public GameObject settingsCanvas;

    public GameObject settingsCursor;

    public GameObject controlsCanvas;

    public GameObject creditsCanvas;

    public GameObject uiController;

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

    }

    void Down()
    {

    }

    void Left()
    {
        
    }

    void Right()
    {
        
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
