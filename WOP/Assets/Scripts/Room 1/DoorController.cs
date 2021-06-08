using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject room2Portal;

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the portal to inactive and set the door to active
        room2Portal.SetActive(false);
        door.SetActive(true);
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        // If the player has solved the puzzles then set the door to inactive and set the portal to active
        if (gVar.normalButton && gVar.iceButton)
        {
            door.SetActive(false);
            room2Portal.SetActive(true);
        }
    }
}
