using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles all of the different portals in the game and will detect what the player has hit and what to do when they hit it
public class PlayerTeleporter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Room 1")
        {
            SceneManager.LoadScene("Room 1");
        }

        if (collision.gameObject.tag == "Room 2")
        {
            SceneManager.LoadScene("Room 2");
        }

        if (collision.gameObject.tag == "Settings")
        {
            // Here we will make the game open the settings menu
        }

        if (collision.gameObject.tag == "Controls")
        {
            // Here we will make the game show the controls options to the player
        }

        if (collision.gameObject.tag == "Credits")
        {
            // Here we will have a shameless plug of our names and how we have contributed to this project
        }
    }
}
