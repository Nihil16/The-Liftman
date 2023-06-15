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

        myAnim.SetBool("SnappingAnim", true);
        yield return new WaitForSeconds(Soloution);
        myAnim.enabled = false;

        Debug.Log("STOP");
    }
}
