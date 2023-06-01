using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrGloom : MonoBehaviour
{

    public GameObject RightTop;
    public GameObject RightBot;

    private void OnEnable()
    {
        GameEvents.OnDisplayPuzzle += OnDisplayPuzzle;
    }

    private void OnDisable()
    {
        GameEvents.OnDisplayPuzzle -= OnDisplayPuzzle;
    }

    public void Start()
    {
        Blink();
    }

    public void OnDisplayPuzzle(int Soloution)
    {
        while(Soloution > 0)
        {
            
            Soloution--;
        }
    }

    public void Blink()
    {
        //close
        RightTop.transform.rotation = new Quaternion(-0.25f, -0.25f, 0.25f, 360);
        RightBot.transform.rotation = new Quaternion(-0.25f, 0.25f, -0.25f, 360);

        //open
        RightTop.transform.rotation = new Quaternion(0, -0.25f, 0.25f, 360);
        RightBot.transform.rotation = new Quaternion(0, 0.25f, -0.25f, 360);
    }
}   
