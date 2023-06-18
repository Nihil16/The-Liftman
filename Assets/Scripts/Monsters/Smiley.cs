using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smiley : MonoBehaviour
{
    public List<GameObject> Teeth;
    public Animator myAnim;
    private void OnEnable()
    {
        GameEvents.OnDisplayPuzzle += OnDisplayPuzzle;
    }

    private void OnDisable()
    {
        GameEvents.OnDisplayPuzzle -= OnDisplayPuzzle;
    }
    private void Start()
    {
        for (int i = 0; i < Teeth.Count; i++)
        {
            Teeth[i].SetActive(false);
        }

        for (int i = 0; i < PuzzleManager.Solution; i++)
        {
            Teeth[i].SetActive(true);
        }
    }



    public void OnDisplayPuzzle()
    {
        StartCoroutine(Open(PuzzleManager.Solution));
    }

    private IEnumerator Open(int Soloution)
    {
        


        for (int i = 0; i < 3; i++)
        {
            myAnim.SetTrigger("MouthOpen");
            yield return new WaitForSeconds(4f);
        }
    }
}
