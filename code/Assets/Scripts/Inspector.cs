using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* (C) Mihnea S. Teodorescu & Andrei Dumitriu, November 2019
 */

public class Inspector : MonoBehaviour
{
    public GameObject[] textFields;
    public Text text;
    public bool exists = true;

    public void ofpx (double px)
    {
        text = textFields[0].GetComponent<Text>();
        text.text= px.ToString();
    }

    public void ofpy(double py)
    {
        text = textFields[1].GetComponent<Text>();
        text.text = py.ToString();
    }

    public void ofpz(double pz)
    {
        text = textFields[2].GetComponent<Text>();
        text.text = pz.ToString();
    }

    public void ofvx(double vx)
    {
        text = textFields[3].GetComponent<Text>();
        text.text = vx.ToString();
    }

    public void ofvy(double vy)
    {
        text = textFields[4].GetComponent<Text>();
        text.text = vy.ToString();
    }

    public void ofvz(double vz)
    {
        text = textFields[5].GetComponent<Text>();
        text.text = vz.ToString();
    }

    public void ofax(double ax)
    {
        text = textFields[6].GetComponent<Text>();
        text.text = ax.ToString();
    }

    public void ofay(double ay)
    {
        text = textFields[7].GetComponent<Text>();
        text.text = ay.ToString();
    }

    public void ofaz(double az)
    {
        text = textFields[8].GetComponent<Text>();
        text.text = az.ToString();
    }

    public void ofm(double m)
    {
        text = textFields[9].GetComponent<Text>();
        text.text = m.ToString();
    }

    public void ofr(double r)
    {
        text = textFields[10].GetComponent<Text>();
        text.text = r.ToString();
    }
    public void ok()
    {
        exists = false;
        Destroy(gameObject);
    }

    public bool isActive()
    {
        return exists;
    }
}
