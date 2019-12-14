using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* (C) Mihnea S. Teodorescu & Andrei Dumitriu, November 2019
 */

public class CustomizationScript : MonoBehaviour
{
    public GameObject AddSphereWindow;
    public GameObject button1;
    public GameObject button2;
    public GameObject manager;
    public GameObject minstance;
    public GameObject sphere;
    public GameObject instance;
    public float x=0, y=0, z=0;
    public double vx = 0, vy = 0, vz = 0;
    public double ax = 0, ay = 0, az = 0;
    public double px = 0, py = 0, pz = 0;
    public double m = 1e7;
    public float r = 1;
    public double ar = 1e7;

    public void addSphere()
    {
        AddSphereWindow.SetActive(true);
        instance = Instantiate(sphere) as GameObject;
        instance.GetComponent<InspectSphere>().ready = false;
        instance.transform.position = new Vector3(x, y, z);
        instance.transform.localScale = new Vector3(r, r, r);

    }

    public void ifpx (string input)
    {
        px = double.Parse(input);
        x = (float)(px / 1e9);
        instance.transform.position = new Vector3(x, y, z);
    }
    public void ifpy(string input)
    {
        py = double.Parse(input);
        y = (float)(py / 1e9);
        instance.transform.position = new Vector3(x, y, z);
    }
    public void ifpz(string input)
    {
        pz = double.Parse(input);
        z = (float)(pz / 1e9);
        instance.transform.position = new Vector3(x, y, z);
    }

    public void ifvx(string input)
    {
        vx = double.Parse(input);
    }
    public void ifvy(string input)
    {
        vy = double.Parse(input);
    }
    public void ifvz(string input)
    {
        vz = double.Parse(input);
    }

    public void ifax(string input)
    {
        ax = double.Parse(input);
    }

    public void ifay(string input)
    {
        ay = double.Parse(input);
    }

    public void ifaz(string input)
    {
        az = double.Parse(input);
    }
    public void ifm(string input)
    {
        m = double.Parse(input);
    }
    public void ifr(string input)
    {
        ar = double.Parse(input);
        r = (float)(ar / 1e7);
        instance.transform.localScale = new Vector3(r, r, r);
    }
    public void addSphereOk()
    {
        instance.GetComponent<InspectSphere>().vel = new Vector3d(vx, vy, vz);
        instance.GetComponent<InspectSphere>().acc = new Vector3d(ax, ay, az);
        instance.GetComponent<InspectSphere>().rad = ar;
        instance.GetComponent<InspectSphere>().ax = px;
        instance.GetComponent<InspectSphere>().ay = py;
        instance.GetComponent<InspectSphere>().az = pz;
        instance.GetComponent<InspectSphere>().ready = true;
        instance.GetComponent<InspectSphere>().mass = m;
        AddSphereWindow.SetActive(false);
    }
    
    public void endCustomization()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        minstance = Instantiate(manager) as GameObject;

    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
