using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodController : MonoBehaviour
{
    public GameObject[] bloodTiles;

    public int iterations = 0;

    /// Awake is called when the script instance is being loaded.
    void Awake()
    {
        bloodTiles = GameObject.FindGameObjectsWithTag("Blood");

        foreach (GameObject bloodTile in bloodTiles)
        {
            bloodTile.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BloodFlow", 1f, 4f);
    }

    void BloodFlow()
    {
        iterations++;

        if (iterations == 42)
        {
            CancelInvoke("BloodFlow");
            
            // Stop the level
        }
        else
        {
            bloodTiles[iterations - 1].SetActive(true);
        }
    }
}
