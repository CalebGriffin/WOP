using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netpickup : MonoBehaviour
{
    public NetSpawner NetSpawner;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Net")
        {
            Destroy(other.gameObject);
            NetSpawner.Setup();
        }
    }
}
