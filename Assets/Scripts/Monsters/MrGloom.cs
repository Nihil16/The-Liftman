using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrGloom : MonoBehaviour
{
    public Animator myAnim;

    private void OnEnable()
    {
        GameEvents.OnDisplayPuzzle += OnDisplayPuzzle;
    }

    private void OnDisable()
    {
        GameEvents.OnDisplayPuzzle -= OnDisplayPuzzle;
    }

    public void OnDisplayPuzzle(int Soloution)
    {
        for (int i = 0; i < Soloution; i++)
        {
            Blink();
        }
    }

    public void Blink()
    {
        Debug.Log("Blink");
        myAnim.Play("Blink");

    }
}   
