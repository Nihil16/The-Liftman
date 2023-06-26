using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    public static int CurrentMonster;
    public List<int> MonsterLiking;

    private void OnEnable()
    {
        GameEvents.OnHelpManager += OnHelpManager;  
        GameEvents.OnDisplayHelp += OnDisplayHelp;  
    }

    private void OnDisable()
    {
        GameEvents.OnHelpManager -= OnHelpManager;
        GameEvents.OnDisplayHelp -= OnDisplayHelp;
    }
    void OnDisplayHelp()
    {
        if((MonsterLiking[CurrentMonster] == 0))
        {
            Debug.Log("Intro");
           
        }
        else if ((MonsterLiking[CurrentMonster] == -1))
        {
            Debug.Log("Helping");

        }
        else if ((MonsterLiking[CurrentMonster] > 0))
        {
            Debug.Log("I Like you");

        }
    }
    void OnHelpManager(int Num)
    {

        if (Num == -1)
        {
            (MonsterLiking[CurrentMonster]) = Num;
        }
        else
        {
            (MonsterLiking[CurrentMonster]) = (MonsterLiking[CurrentMonster]) +1    ;
        }
    }



}
