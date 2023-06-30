 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{




    public static int Solution;

    public static bool CorrectAnswer;

    private bool First = true;


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
        if (MonsterManager.MonsterHere == false)
        {
            Solution = UnityEngine.Random.Range(1, 9);
            Debug.Log($"solution is {Solution}, Current floor is {ElavatorManager.CurrentFloor}");
            if (Solution == ElavatorManager.CurrentFloor)
            {
                Debug.Log($"solution was reset");
                OnMonsterSummon();
            }
        }
        
    }

    public void OnButtonPressed(int Answer)
    {
        Debug.Log(Answer + " Answer");

        if (Answer == Solution)
        {
            
            CorrectAnswer = true;
            ElevatorNoiseManager.CorrectFloor = true; 
            Debug.Log("Correct");
            GameEvents.OnHelpManager?.Invoke(+1);

        }
        if (Answer != Solution)
        {
            CorrectAnswer = false;
            ElevatorNoiseManager.CorrectFloor = false;
            Debug.Log("Incorrect");
            if (First == false)
            {
                GameEvents.OnHelpManager?.Invoke(-1);

            }
            First = false;
        }


    }


}
