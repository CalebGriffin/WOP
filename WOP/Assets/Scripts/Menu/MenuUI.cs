using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject resetCanvas;

    public GameObject quitCanvas;

    public GameObject resetCursor;

    public GameObject quitCursor;

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
            if (quitCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(-150f, -40f))
            {
                Application.Quit();
            }
            else if (quitCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(50f, -40f))
            {
                quitCanvas.SetActive(false);
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
