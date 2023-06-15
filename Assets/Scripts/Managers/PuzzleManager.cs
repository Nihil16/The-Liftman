 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static int Solution;


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
            Debug.Log($"solution is {Solution}, Current floor is {ElavatorManager.CurrentFloor}");
            if (Solution == ElavatorManager.CurrentFloor)
            {
                Debug.Log($"solution was reset");
                OnMonsterSummon();
            }
       
        
    }

    public void OnButtonPressed(int Answer)
    {
        Debug.Log(Answer + "Answer");
        

        if (Answer == Solution)
        {
            Debug.Log("Correct");
        }
        if (Answer != Solution)
        {
            Debug.Log("Incorrect");
        }
    }


}
