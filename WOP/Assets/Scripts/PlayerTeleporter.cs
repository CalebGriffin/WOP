using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles all of the different portals in the game and will detect what the player has hit and what to do when they hit it
public class PlayerTeleporter : MonoBehaviour
{
    // References all of the UI elements
    public GameObject quitCanvas;

    public GameObject settingsCanvas;

    public GameObject controlsCanvas;

    public GameObject creditsCanvas;

    public GameObject uiController;

    // When the player collides with a portal which should take them to the next level then open it, if it is a UI portal then display the UI
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Room 1":
                SceneManager.LoadScene("Room 1");
                break;

            case "Room 2":
                SceneManager.LoadScene("Room 2");
                break;
            
            case "Menu":
                gVar.backToMenu = true;
                SceneManager.LoadScene("Menu");
                break;
            
            case "Settings":
                settingsCanvas.SetActive(true);
                uiController.SetActive(true);
                transform.position = new Vector3(14.5f, -1.5f, 0f);
                break;
            
            case "Controls":
                controlsCanvas.SetActive(true);
                uiController.SetActive(true);
                transform.position = new Vector3(-3.5f, -4.5f, 0f);
                break;
            
            case "Credits":
                creditsCanvas.SetActive(true);
                uiController.SetActive(true);
                transform.position = new Vector3(3.5f, -8.5f, 0f);
                break;

            case "Quit":
                quitCanvas.SetActive(true);
                uiController.SetActive(true);
                transform.position = new Vector3(13.5f, -9.5f, 0f);
                break;
            
            default:
                break;
        }
    }
}
