using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* (C) Mihnea S. Teodorescu & Andrei Dumitriu, November 2019
 */

public class BeginThing : MonoBehaviour
{
    public GameObject pf;
    public GameObject instance;
    
    // Start is called before the first frame update
    void delay()
    {
        instance = Instantiate(pf) as GameObject;
    }
    
    void Start()
    {
        Invoke("delay", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
