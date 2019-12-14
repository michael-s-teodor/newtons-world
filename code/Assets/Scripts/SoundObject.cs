using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* (C) Mihnea S. Teodorescu & Andrei Dumitriu, November 2019
 */

public class SoundObject : MonoBehaviour
{
    public bool volume;
    public void Music()
    {
        volume = !volume;
        GetComponent<AudioSource>().enabled = volume;
    }

    private void Awake()
    {
        volume = true;
        DontDestroyOnLoad(this.gameObject);
    }
}
