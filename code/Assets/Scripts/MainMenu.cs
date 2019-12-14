using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* (C) Mihnea S. Teodorescu & Andrei Dumitriu, November 2019
 */

public class MainMenu : MonoBehaviour
{
    public GameObject HelpPanel;
    public GameObject soundPrefab;
    public GameObject soundObject;
    
    public void PlayEarth()
    {
        SceneManager.LoadScene(1);
    }

    public void PlaySolar()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayCollsion()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayCustom()
    {
        SceneManager.LoadScene(4);
    }

    public void ActivateHelp()
    {
        HelpPanel.SetActive(true);
    }

    public void DeactivateHelp()
    {
        HelpPanel.SetActive(false);
    }

    public void volume()
    {
        soundObject.GetComponent<SoundObject>().Music();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        if (!GameObject.FindGameObjectWithTag("Sound Source"))
        {
            Instantiate(soundPrefab);
        }
        soundObject = GameObject.FindGameObjectWithTag("Sound Source");
    }
}

