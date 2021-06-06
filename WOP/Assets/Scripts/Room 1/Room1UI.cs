using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1UI : MonoBehaviour
{
    public GameObject resetCanvas;

    public GameObject quitCanvas;

    public GameObject resetCursor;

    public GameObject quitCursor;

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
        if (resetCanvas.activeSelf)
        {
            if (resetCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(-150f, -40f))
            {
                
            }
            else if (resetCursor.GetComponent<RectTransform>().anchoredPosition == new Vector2(50f, -40f))
            {

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

            }
        }
    }

    private void OnEnable() 
    {
        controls.Menu.Enable();
    }

    private void OnDisable()
    {
        controls.Menu.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
