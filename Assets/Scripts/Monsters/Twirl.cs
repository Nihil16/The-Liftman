using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twirl : MonoBehaviour
{
    public List<GameObject> ListOfParticles;


    private void OnEnable()
    {
        GameEvents.OnDisplayPuzzle += OnDisplayPuzzle;
    }

    private void OnDisable()
    {
        GameEvents.OnDisplayPuzzle -= OnDisplayPuzzle;
    }

    private void OnDisplayPuzzle()
    {
        Instantiate(ListOfParticles[PuzzleManager.Solution-1], this.transform.position, Quaternion.identity);
    }
}
