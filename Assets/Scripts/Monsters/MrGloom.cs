using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MrGloom : MonoBehaviour
{
    public Animator myAnim;
    public int Count = 0;

    private void OnEnable()
    {
        GameEvents.OnDisplayPuzzle += OnDisplayPuzzle;
    }

    private void OnDisable()
    {
        GameEvents.OnDisplayPuzzle -= OnDisplayPuzzle;
    }

    public void OnDisplayPuzzle()
    {
        StartCoroutine(Blink(PuzzleManager.Solution));
       
    }




    private IEnumerator Blink(int Soloution)
    {

        for (int i = 0; i < Soloution; i++)
        {
            myAnim.SetTrigger("Blink");
            yield return new WaitForSeconds(1.2f);
        }

    }
}   
