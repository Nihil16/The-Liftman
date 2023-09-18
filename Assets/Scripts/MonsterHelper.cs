using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHelper : MonoBehaviour
{
    public List<AudioClip> AudioClips;
    public enum Name { Smiley, BottomHat, Cory, Hoodwink, Twirl, MrGloom}
    public Name MonsterName;
    public MonsterDataManager MonsterData;

    public int MonsterLike;
    public int MonsterGoodVoice;
    public int MonsterBadVoice;
    public int MonsterNeutralVoice;

    private void Awake()
    {
        switch (MonsterName)
        {
            case (Name.Smiley):
                {
                    MonsterLike = MonsterData.Smiley.MonsterLike;
                    MonsterGoodVoice = MonsterData.Smiley.MonsterGoodVoice;
                    MonsterBadVoice = MonsterData.Smiley.MonsterBadVoice;
                    MonsterNeutralVoice = MonsterData.Smiley.MonsterNeutralVoice;
                    break;
                }
            case (Name.BottomHat):
                {
                    MonsterLike = MonsterData.BottomHat.MonsterLike;
                    MonsterGoodVoice = MonsterData.BottomHat.MonsterGoodVoice;
                    MonsterBadVoice = MonsterData.BottomHat.MonsterBadVoice;
                    MonsterNeutralVoice = MonsterData.BottomHat.MonsterNeutralVoice;
                    break;
                }
            case (Name.Cory):
                {
                    MonsterLike = MonsterData.Cory.MonsterLike;
                    MonsterGoodVoice = MonsterData.Cory.MonsterGoodVoice;
                    MonsterBadVoice = MonsterData.Cory.MonsterBadVoice;
                    MonsterNeutralVoice = MonsterData.Cory.MonsterNeutralVoice;
                    break;
                }
            case (Name.MrGloom):
                {
                    MonsterLike = MonsterData.MrGloom.MonsterLike;
                    MonsterGoodVoice = MonsterData.MrGloom.MonsterGoodVoice;
                    MonsterBadVoice = MonsterData.MrGloom.MonsterBadVoice;
                    MonsterNeutralVoice = MonsterData.MrGloom.MonsterNeutralVoice;
                    break;
                }
            case (Name.Hoodwink):
                {
                    MonsterLike = MonsterData.Hoodwink.MonsterLike;
                    MonsterGoodVoice = MonsterData.Hoodwink.MonsterGoodVoice;
                    MonsterBadVoice = MonsterData.Hoodwink.MonsterBadVoice;
                    MonsterNeutralVoice = MonsterData.Hoodwink.MonsterNeutralVoice;
                    break;
                }
            case (Name.Twirl):
                {
                    MonsterLike = MonsterData.Twirl.MonsterLike;
                    MonsterGoodVoice = MonsterData.Twirl.MonsterGoodVoice;
                    MonsterBadVoice = MonsterData.Twirl.MonsterBadVoice;
                    MonsterNeutralVoice = MonsterData.Twirl.MonsterNeutralVoice;
                    break;
                }
        }

    }

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
        if((MonsterLike == 0))
        {
            GameEvents.OnReceiveVoice?.Invoke(AudioClips[MonsterNeutralVoice]);
            MonsterNeutralVoice++;
            
        }
        else if ((MonsterLike == -1))
        {
            GameEvents.OnReceiveVoice?.Invoke(AudioClips[MonsterGoodVoice]);
            MonsterGoodVoice++;
        }
        else if ((MonsterLike > 0))
        {
            GameEvents.OnReceiveVoice?.Invoke(AudioClips[MonsterBadVoice]);
            MonsterBadVoice++;
        }
    }
    void OnHelpManager(int Num)
    {

        if (Num == -1)
        {
            (MonsterLike) = -1;
        }
        else
        {
            (MonsterLike) ++;
        }
    }



}
