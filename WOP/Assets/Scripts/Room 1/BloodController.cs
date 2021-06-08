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

        bloodTiles = GameObject.FindGameObjectsWithTag("Blood").ToList();

        bloodTilesSorted = bloodTiles.OrderBy(bloodTile => bloodTile.name).ToArray();

        foreach (GameObject bloodTile in bloodTilesSorted)
        {
            bloodTile.SetActive(false);
        }

        controls = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BloodFlow", 1f, 4f);
    }

    void BloodFlow()
    {
        if (!gVar.isPaused)
        {
            iterations++;
        }

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
            if (!gVar.isPaused)
            {
                bloodTilesSorted[iterations - 1].SetActive(true);
            }
        }
    }

    public IEnumerator WaitToRestart()
    {
        gVar.isPaused = true;

        yield return new WaitForSeconds(5f);

        gVar.isPaused = false;

        SceneManager.LoadScene("Room 1");
    }
}
