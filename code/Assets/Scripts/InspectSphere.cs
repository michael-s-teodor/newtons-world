using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* (C) Mihnea S. Teodorescu & Andrei Dumitriu, November 2019
 */

public class InspectSphere : MonoBehaviour
{
    public Vector3d vel;
    public double vx, vy, vz;
    public Vector3d acc;
    public double accx, accy, accz;
    public double mass;
    public double rad;
    public float scale;
    public GameObject inspector;
    public GameObject instance;
    public GameObject canvas;
    public bool popup = false;
    public float x, y, z;
    public double ax, ay, az;
    public bool ready = true;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        vel = new Vector3d(vx, vy, vz);
        acc = new Vector3d(accx, accy, accz);
    }

    // Update is called once per frame
    void Update()
    {
        if(popup)
        {
            instance.GetComponent<Inspector>().ofpx(ax);
            instance.GetComponent<Inspector>().ofpy(ay);
            instance.GetComponent<Inspector>().ofpz(az);
            instance.GetComponent<Inspector>().ofvx(vel[0]);
            instance.GetComponent<Inspector>().ofvy(vel[1]);
            instance.GetComponent<Inspector>().ofvz(vel[2]);
            instance.GetComponent<Inspector>().ofax(acc[0]);
            instance.GetComponent<Inspector>().ofay(acc[1]);
            instance.GetComponent<Inspector>().ofaz(acc[2]);
            instance.GetComponent<Inspector>().ofm(mass);
            instance.GetComponent<Inspector>().ofr(rad);
            popup = instance.GetComponent<Inspector>().isActive();
            if(!popup)
            {
                instance.SetActive(false);
            }
        }
        if(ready)
        {
            x = (float)(ax / 1e9);
            y = (float)(ay / 1e9);
            z = (float)(az / 1e9);
            scale = (float)(rad / 1e7);
            transform.position = new Vector3(x, y, z);
            transform.localScale = new Vector3(scale, scale, scale);
            accx = acc.x;
            accy = acc.y;
            accz = acc.z;
            vx = vel.x;
            vy = vel.y;
            vz = vel.z;
        }

    }

    private void OnMouseDown()
    {
        inspector.SetActive(true);
        instance = Instantiate(inspector) as GameObject;
        instance.SetActive(true);
        instance.transform.SetParent(canvas.transform);
        instance.transform.localScale = new Vector3(1.7226f, 1.9422f, 1);
        instance.transform.localPosition = new Vector3(-678, -18.2f, 0); 
        popup = true;
    }
}
