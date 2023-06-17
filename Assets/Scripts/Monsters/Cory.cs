using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cory : MonoBehaviour
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

    public void OnDisplayPuzzle()
    {
        StartCoroutine(Snapping(PuzzleManager.Solution));
       
    }

    private IEnumerator Snapping(int Soloution)
    {
        
        myAnim.SetTrigger("PuzzleSnap");
        
        yield return new WaitForSeconds(0.5f * Soloution);
        
        myAnim.speed = 0;
        Debug.Log("STOP");
    }
}
