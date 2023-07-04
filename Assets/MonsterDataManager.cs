using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName = "MonsterData",menuName = "MonsterData", order = 0)]

public class MonsterDataManager : ScriptableObject
{
    public MonsterData Smiley;
    public MonsterData Cory;
    public MonsterData BottomHat;
    public MonsterData Twirl;
    public MonsterData MrGloom;
    public MonsterData Hoodwink;

    private void Start()
    {
        Smiley.Zero();
        Cory.Zero();
        Twirl.Zero();
        BottomHat.Zero();
        Hoodwink.Zero();
        MrGloom.Zero();
    }
}




public class MonsterData
{
    public int MonsterLike;
    public int MonsterGoodVoice;
    public int MonsterBadVoice;
    public int MonsterNeutralVoice;

    public void Zero()
    {
      MonsterLike = 0;
      MonsterGoodVoice = 0;
      MonsterBadVoice = 0;
      MonsterNeutralVoice = 0;
    }
}




