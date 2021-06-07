using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Banana")
            Destroy(other.gameObject);
    }
}
