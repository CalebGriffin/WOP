using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles all of the different portals in the game and will detect what the player has hit and what to do when they hit it
public class PlayerTeleporter : MonoBehaviour
{
    public GameObject quitCanvas;

    public GameObject settingsCanvas;

    public GameObject controlsCanvas;

    public GameObject creditsCanvas;

    public GameObject uiController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Room 1":
                SceneManager.LoadScene("Room 1");
                break;

            case "Room 2":
                SceneManager.LoadScene("Room 1");
                break;
            
            case "Menu":
                gVar.backToMenu = true;
                SceneManager.LoadScene("Menu");
                break;
            
            case "Settings":
                break;
            
            case "Controls":
                break;
            
            case "Credits":
                break;

            case "Quit":
                break;
            
            default:
                break;
        }
    }
}
