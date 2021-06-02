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
        room2Portal.SetActive(false);
        door.SetActive(true);
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        if (gVar.normalButton && gVar.iceButton)
        {
            door.SetActive(false);
            room2Portal.SetActive(true);
        }
    }
}
