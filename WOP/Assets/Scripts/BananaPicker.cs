using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BananaPicker : MonoBehaviour
{
    public FloorAndBanana FloorAndBanana;
    public ExitDoor ExitDoor;
    public Floor Floor;

    private float banana = 0;

    public TextMeshProUGUI textBanana;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Banana")
        {
            banana++;
            textBanana.text = banana.ToString();

            Destroy(other.gameObject);
        }
        if (banana == 10)
        {
            FloorAndBanana.Setup();
            ExitDoor.Setup();
            Floor.Setup();
        }
    }
}
