using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* (C) Mihnea S. Teodorescu & Andrei Dumitriu, November 2019
 */

public class Physics : MonoBehaviour
{
    public struct SphereObject
    {
        public bool     exists;
        public double   mass, radius;
        public Vector3d pos, vel, acc;
    }
    public SphereObject[] sphere;
    public GameObject[]   game_sphere;
    public int            num_of_spheres;
    public bool           paused = false;
    public int            speed  = 512;
    public double         t = 0, dt = 1;
    private double        G = 6.674e-11;
    public GameObject     TheText;
    public Text           TextField;

    double Magnitude(Vector3d vec)
    {
        return Math.Sqrt(vec.x * vec.x + vec.y * vec.y + vec.z * vec.z);
    }

    Vector3d GravForce(int i, int j)
    {
        Vector3d r_vec, r_hat, force_vec;
        double   r_mag, force_mag;
        r_vec     = sphere[i].pos - sphere[j].pos;
		r_mag     = Magnitude(r_vec);
        r_hat     = r_vec / r_mag;
		force_mag = G * sphere[i].mass * sphere[j].mass / (r_mag * r_mag);
        force_vec = -force_mag * r_hat;
		return force_vec;
    }

    void UpdateAcc()
    {
    	for (int i = 0; i < num_of_spheres; i++)
        {
            sphere[i].acc = new Vector3d(0, 0, 0);
        }
    	for (int i = 0; i < num_of_spheres; i++)
        {
            if (sphere[i].exists)
            {
            	for (int j = i+1; j < num_of_spheres; j++)
            	{
            		if (sphere[j].exists)
            		{
            		    sphere[i].acc += GravForce(i, j) / sphere[i].mass;
            			sphere[j].acc += GravForce(j, i) / sphere[j].mass;
            		}
            	}
            }
        }
    }

    void UpdateVelPos()
    {
    	for (int i = 0; i < num_of_spheres; i++)
        {
            if (sphere[i].exists)
            {
            	sphere[i].vel += sphere[i].acc * dt;
            	sphere[i].pos += sphere[i].vel * dt;
            }
        }
    }

    void UpdateGameSpheres()
    {
        for (int i = 0; i < num_of_spheres; i++)
        {
            if (!sphere[i].exists)
            {
                game_sphere[i].SetActive(false);
            }
            game_sphere[i].GetComponent<InspectSphere>().ax  = sphere[i].pos.x;
            game_sphere[i].GetComponent<InspectSphere>().ay  = sphere[i].pos.y;
            game_sphere[i].GetComponent<InspectSphere>().az  = sphere[i].pos.z;
            game_sphere[i].GetComponent<InspectSphere>().rad = sphere[i].radius;
            game_sphere[i].GetComponent<InspectSphere>().vel = sphere[i].vel;
            game_sphere[i].GetComponent<InspectSphere>().acc = sphere[i].acc;
        }
    }

    void MergeCollided()
    {
        for (int i = 0; i < num_of_spheres; i++)
        {
            if (sphere[i].exists)
            {
                for (int j = i+1; j < num_of_spheres; j++)
                {
                    if (sphere[j].exists)
                    {
                        Vector3d r_vec = sphere[i].pos - sphere[j].pos;
                        double   r_mag = Magnitude(r_vec);
                        if (r_mag - sphere[i].radius - sphere[j].radius <= 0)
                        {
                            if (sphere[i].mass < sphere[j].mass)
                            {
                                int t = i;
                                i = j;
                                j = t;
                            }
                            sphere[j].exists  =  false;
                            sphere[i].vel     =  (sphere[i].vel * sphere[i].mass + sphere[j].vel * sphere[j].mass) / (sphere[i].mass + sphere[j].mass);
                            sphere[i].mass    += sphere[j].mass;
                            sphere[i].radius  =  Math.Pow(Math.Pow(sphere[i].radius, 3) + Math.Pow(sphere[j].radius, 3), 1.0/3.0);
                            UpdateGameSpheres();
                            UpdateAcc();
                        }
                    }
                }
            }
        }
    }
    
    void Start() 
    {
        game_sphere    = GameObject.FindGameObjectsWithTag("Sphere");
        num_of_spheres = game_sphere.Length;
        sphere         = new SphereObject[num_of_spheres];
        for (int i = 0; i < num_of_spheres; i++)
        {
            sphere[i].exists  = true;
            sphere[i].pos     = new Vector3d(game_sphere[i].GetComponent<InspectSphere>().ax, game_sphere[i].GetComponent<InspectSphere>().ay, game_sphere[i].GetComponent<InspectSphere>().az);
            sphere[i].vel     = game_sphere[i].GetComponent<InspectSphere>().vel;
            sphere[i].mass    = game_sphere[i].GetComponent<InspectSphere>().mass;
            sphere[i].radius  = game_sphere[i].GetComponent<InspectSphere>().rad;
        }
        TheText = GameObject.FindGameObjectWithTag("Speed Text");
        TextField = TheText.GetComponent<Text>();
        Display();
    }

    public void Display()
    {
        TextField.text = "speed: " + speed.ToString() + "  dt: " + dt.ToString();
    }

    void GetInput()
    {
        if (Input.GetKeyDown("space"))
        {
            paused = !paused;
        }
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown("r") && speed < 262144)
        {
            speed *= 2;
            Display();
        }
        if (Input.GetKeyDown("f") && speed > 1)
        {
            speed /= 2;
            Display();
        }
        if (Input.GetKeyDown("t") && dt < 10000)
        {
            dt *= 10;
            Display();
        }
        if (Input.GetKeyDown("g") && dt > 1)
        {
            dt /= 10;
            Display();
        }
    }

    void Update()
    {
        GetInput();
        if (!paused)
        {
            do
            {
                UpdateAcc();
                UpdateVelPos();
                MergeCollided();
                t += dt;
            } 
            while (t % speed != 0);
        }
        UpdateGameSpheres();
    }
}