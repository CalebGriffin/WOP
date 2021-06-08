using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room1UI : MonoBehaviour
{
    // References to all of the UI elements
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

        //controls.Menu.Up.performed += ctx => Up();
        //controls.Menu.Down.performed += ctx => Down();
        controls.Menu.Left.performed += ctx => Left();
        controls.Menu.Right.performed += ctx => Right();
        controls.Menu.Confirm.performed += ctx => Confirm();
    }

    void Left()
    {
        // Moves the cursor left on the appropriate UI menu
        Debug.Log("Left has been pressed");

        if (resetCanvas.activeSelf)
        {
            if (resetCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(50f, -40f))
            {
                resetCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(-150f, -40f);
            }
        }
        else if (quitCanvas.activeSelf)
        {
            if (quitCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(50f, -40f))
            {
                quitCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(-150f, -40f);
            }
        }
    }

    void Right()
    {
        // Moves the cursor right on the appropriate UI menu
        if (resetCanvas.activeSelf)
        {
            if (resetCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(-150f, -40f))
            {
                resetCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(50f, -40f);
            }
        }
        else if (quitCanvas.activeSelf)
        {
            if (quitCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(-150f, -40f))
            {
                quitCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(50f, -40f);
            }
        }
    }

    void Confirm()
    {
        // Carrys out an action based on which canvas is active and where the cursor is on the canvas
        if (resetCanvas.activeSelf)
        {
            if (resetCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(-150f, -40f))
            {
                gVar.normalButton = false;
                gVar.iceButton = false;
                gVar.isFilled = false;

                resetCanvas.SetActive(false);
                SceneManager.LoadScene("Room 1");
                uiController.SetActive(false);
            }
            else if (resetCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(50f, -40f))
            {
                resetCanvas.SetActive(false);
                uiController.SetActive(false);
            }
        }
        else if (quitCanvas.activeSelf)
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

    // Enables and Disables the controls when the object is enabled and disabled
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
