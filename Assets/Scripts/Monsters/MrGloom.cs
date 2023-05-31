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
        RightTop.transform.Rotate(-90.0f, -90.0f, 90.0f, Space.Self);
        RightBot.transform.Rotate(-90.0f, 90.0f, -90.0f, Space.Self);
    }
}   
