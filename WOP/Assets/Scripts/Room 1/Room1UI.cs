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

    }

    void Right()
    {

    }

    void Confirm()
    {

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
