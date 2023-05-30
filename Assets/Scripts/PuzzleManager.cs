using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int Solution;


    private void OnEnable()
    {
        GameEvents.OnMonsterSummon += OnMonsterSummon;
        GameEvents.OnButtonPressed += OnButtonPressed;
    }
    private void OnDisable()
    {
        GameEvents.OnMonsterSummon -= OnMonsterSummon;
        GameEvents.OnButtonPressed -= OnButtonPressed;

    }


    public void OnMonsterSummon()
    {
        Solution = UnityEngine.Random.Range(1, 9);

    }

    public void OnButtonPressed(int Answer)
    {
        if (Answer == Solution)
        {
            Debug.Log("Correct");
        }
        if (Answer == Solution)
        {
            Debug.Log("Incorrect");
        }
    }


}
