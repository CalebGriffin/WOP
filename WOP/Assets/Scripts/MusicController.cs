using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will make sure that the music will not be destroyed when moving between scenes and if there are too many music objects it will remove one
public class MusicController : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
