using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Play;
    public GameObject Credits;
    public GameObject Credits2;
    public GameObject Exit;
    public GameObject Back;

    private void Start()
    {
        StartMenu();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Credit()
    {
        Credits2.SetActive(true);
        Play.SetActive(false);
        Credits.SetActive(false);
        Exit.SetActive(false);
    }    
    public void BackToMenu()
    {
        StartMenu();
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void StartMenu()
    {
        Play.SetActive(true);
        Credits.SetActive(true);
        Credits2.SetActive(false);
        Exit.SetActive(true);
    }

}
