using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using static GameEvents;
using System;

public class MainMenu : MonoBehaviour
{
    public GameObject Play;
    public GameObject Credits;
    public GameObject Credits2;
    public GameObject Exit;
    public GameObject Back;
    public GameObject Shop;

    public GameObject QuitButton;

    private int count;

    public GameObject Item1;


    public GameObject ThankYouText;
    public GameObject DidNotWork;

    public TextMeshProUGUI Text;


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
        Shop.SetActive(false);
        Back.SetActive(true);

        
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
        Shop.SetActive(false);
        Back.SetActive(false);
        QuitButton.SetActive(true);
        Item1.SetActive(false);


        ThankYouText.SetActive(false);
        DidNotWork.SetActive(false);
    }

    public void ShopMenu()
    {
        Credits2.SetActive(false);
        Play.SetActive(false);
        Credits.SetActive(false);
        Exit.SetActive(false);
        Back.SetActive(true);

        Item1.SetActive(true);
    }


    public void Successful()
    {
        ThankYouText.SetActive(true);
        StartCoroutine(Disable());
        
        QuitButton.SetActive(false);
       
        Shop.SetActive(false);


    }



    public void Unsuccessful()
    {
        DidNotWork.SetActive(true);

        Item1.SetActive(false);
        QuitButton.SetActive(false);
        QuitButton.SetActive(false);
        Shop.SetActive(false);
       
    }


    public void CloseMe()
    {
        ThankYouText.SetActive(false);
        DidNotWork.SetActive(false);
        QuitButton.SetActive(true);
        Shop.SetActive(true);
        ShopMenu();
    }


    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.1f);
        Item1.SetActive(false);
        count++;
        Text.text = ("DONATION COINS: " + count);
    }

}
