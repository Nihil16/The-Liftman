using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class ElavatorManager : MonoBehaviour
{
    //List of postions that the elavtor can go to
    public List<Vector3> listOfPosition;

    //All the buttons
    public List<GameObject> Buttons;

    //The two materials that the buttons can switch to
    public List<Material> Materials;


    private int TotalTime; //Total time that the elavtor will take to get to the next floor
    private bool pressed; //If the button is pressed (Changing material_

    public static int CurrentFloor; //What floor we are going to
    private void Start()
    {
        CurrentFloor = 1; //Starting floor
        MonsterManager.MonsterHere = true;
        DoorManager.DoorOpener = false;
        StartCoroutine(Starter());
    }


    private IEnumerator Starter()
    {
        GameEvents.OnLockButton?.Invoke(true);

        MonsterManager.MonsterHere = false;
        DoorManager.DoorOpener = true;
        GameEvents.OnRandomFloor?.Invoke();
        yield return new WaitForSeconds(5f);

        //GameEvents.OnPlayAudio?.Invoke(0);
    }

    private void OnEnable()
    {
        GameEvents.OnButtonPressed += OnButtonPressed;
        GameEvents.OnMonsterLeft += OnMonsterLeft;
        GameEvents.OnRandomFloor += OnRandomFloor;

    }
    private void OnDisable()
    {
        GameEvents.OnButtonPressed -= OnButtonPressed;
        GameEvents.OnMonsterLeft -= OnMonsterLeft;
        GameEvents.OnRandomFloor -= OnRandomFloor;
    }

    private void OnButtonPressed(int Number)
    {

        CurrentFloor = Number; //Set floor to number

        Buttons[Number - 1].GetComponent<MeshRenderer>().material = Materials[0]; //Changes the material



        int SoundTime = UnityEngine.Random.Range(0, 1); //Genorating a fake value of audio. Usually be 0
        int AddTime = UnityEngine.Random.Range(1, 5); //Make it seem more dynamic
        TotalTime = AddTime + SoundTime; //Adds them



        if (TotalTime < 3) //Fast
        {
            int Random = UnityEngine.Random.Range(0, 2);
            if (Random == 0) LeanTween.move(gameObject, listOfPosition[Number - 1], TotalTime).setEaseOutBounce().setOnComplete(this.Arrived);
            else if (Random == 1) LeanTween.move(gameObject, listOfPosition[Number - 1], TotalTime).setEaseOutBack().setOnComplete(this.Arrived);
            else if (Random == 2) LeanTween.move(gameObject, listOfPosition[Number - 1], TotalTime).setEaseOutElastic().setOnComplete(this.Arrived);
            
        }
        else if (TotalTime < 6) //Medium
        {
            int Random = UnityEngine.Random.Range(0, 2);
            if (Random == 0) LeanTween.move(gameObject, listOfPosition[Number - 1], TotalTime).setEaseOutQuart().setOnComplete(this.Arrived);
            else if (Random == 1) LeanTween.move(gameObject, listOfPosition[Number - 1], TotalTime).setEaseOutExpo().setOnComplete(this.Arrived);
            else if (Random == 2) LeanTween.move(gameObject, listOfPosition[Number - 1], TotalTime).setEaseOutCubic().setOnComplete(this.Arrived);
        }
        else if (TotalTime < 26) //Slow
        {
            int Random = UnityEngine.Random.Range(0, 2);
            if (Random == 0) LeanTween.move(gameObject, listOfPosition[Number - 1], TotalTime).setEaseInQuint().setOnComplete(this.Arrived);
            else if (Random == 1) LeanTween.move(gameObject, listOfPosition[Number - 1], TotalTime).setEaseInOutQuart().setOnComplete(this.Arrived);
            else if (Random == 2) LeanTween.move(gameObject, listOfPosition[Number - 1], TotalTime).setEaseInOutExpo().setOnComplete(this.Arrived);
        }



    }
    public void Arrived() //Spawns a monster after the floor is arrive.
    {
        int Random = UnityEngine.Random.Range(1, 3);
        GameEvents.OnOpenDoor?.Invoke(Random, true);


        GameEvents.OnMonsterSummon?.Invoke();



        Buttons[CurrentFloor - 1].GetComponent<MeshRenderer>().material = Materials[1]; //Change the button back
    }

    public void OnMonsterLeft()
    {
        int Random = UnityEngine.Random.Range(0, 7);
        GameEvents.OnOpenDoor?.Invoke(Random, false);
    }

    public void OnRandomFloor()
    {



        int Random = UnityEngine.Random.Range(1, 9);
        while (Random == CurrentFloor)
        {
            Random = UnityEngine.Random.Range(1, 9);
        }

        OnButtonPressed(Random);
    }

}

