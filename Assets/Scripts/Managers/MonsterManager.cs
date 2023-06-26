using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> MonsterList;
    public static bool MonsterHere;
    private int Count = 0;

    private void OnEnable()
    {
        GameEvents.OnMonsterSummon += OnMonsterSummon;
    }
    private void OnDisable()
    {
        GameEvents.OnMonsterSummon -= OnMonsterSummon;
    }

    void OnMonsterSummon()
    {

        if (MonsterHere == false)
        {
            Instantiate(MonsterList[Count], this.transform.position, quaternion.identity);
            Count++;
        }


    }
}
