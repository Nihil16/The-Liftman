using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHelper : MonoBehaviour
{
    public int MonsterLiking;

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
        if((MonsterLiking == 0))
        {
            Debug.Log("Intro");
           
        }
        else if ((MonsterLiking == -1))
        {
            Debug.Log("Helping");

        }
        else if ((MonsterLiking > 0))
        {
            Debug.Log("I Like you");

        }
    }
    void OnHelpManager(int Num)
    {

        if (Num == -1)
        {
            (MonsterLiking) = -1;
        }
        else
        {
            (MonsterLiking) = (MonsterLiking) +1;
        }
    }



}
