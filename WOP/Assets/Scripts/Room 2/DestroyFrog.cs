using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFrog : MonoBehaviour
{
    GameObject froggyAI;
    bool canDestroy = false;

    void OnTriggerEnter(Collider other)
    {
        froggyAI = other.gameObject;
        canDestroy = true;

        if (Input.GetKey(KeyCode.A) && canDestroy)
        {
            Destroy(froggyAI);
            canDestroy = false;
        }
    }
}
