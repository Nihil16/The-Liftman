using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHelper : MonoBehaviour
{
    public int MonsterLiking;
    public List<AudioClip> AudioClips;

    private int GoodC = 0;
    private int BadC = 0;
    private int NeutralC = 0;



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
            GameEvents.OnReceiveVoice?.Invoke(AudioClips[NeutralC]);
            NeutralC++;
        }
        else if ((MonsterLiking == -1))
        {
            GameEvents.OnReceiveVoice?.Invoke(AudioClips[GoodC]);
            GoodC++;
        }
        else if ((MonsterLiking > 0))
        {
            GameEvents.OnReceiveVoice?.Invoke(AudioClips[BadC]);
            BadC++;
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
