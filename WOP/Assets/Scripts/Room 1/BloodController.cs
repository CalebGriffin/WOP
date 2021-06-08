using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloodController : MonoBehaviour
{
    public GameObject[] bloodTilesSorted;

    public List<GameObject> bloodTiles;

    public GameObject timeCanvas;

    public int iterations = 0;

    // Can see the input that the player is making
    PlayerControls controls;

    /// Awake is called when the script instance is being loaded.
    void Awake()
    {
        //bloodTiles = GameObject.FindGameObjectsWithTag("Blood");

        // Gets all of the gameobjects that make up the blood and sort them by name so that they are in order
        bloodTiles = GameObject.FindGameObjectsWithTag("Blood").ToList();

        bloodTilesSorted = bloodTiles.OrderBy(bloodTile => bloodTile.name).ToArray();

        // Sets all of the blood objects to inactive
        foreach (GameObject bloodTile in bloodTilesSorted)
        {
            bloodTile.SetActive(false);
        }

        // Gets a reference to the players controls
        controls = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Every 4 seconds call this function
        InvokeRepeating("BloodFlow", 1f, 4f);
    }

    void BloodFlow()
    {
        // If the game is not paused then increase the number of iterations
        if (!gVar.isPaused)
        {
            iterations++;
        }

        // If the blood has filled up then restart the level
        if (iterations == 42)
        {
            CancelInvoke("BloodFlow");
            if (gVar.normalButton == false || gVar.iceButton == false)
            {
                timeCanvas.SetActive(true);

                gVar.normalButton = false;
                gVar.iceButton = false;
                gVar.isFilled = false;

                StartCoroutine("WaitToRestart");
            }
        }
        else
        {
            // Activate the next blood object
            if (!gVar.isPaused)
            {
                bloodTilesSorted[iterations - 1].SetActive(true);
            }
        }
    }

    // Waits to restart after showing the restart message
    public IEnumerator WaitToRestart()
    {
        gVar.isPaused = true;

        yield return new WaitForSeconds(5f);

        gVar.isPaused = false;

        SceneManager.LoadScene("Room 1");
    }
}
