using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> MonsterList;
    public static bool MonsterHere;
    private int Random;
    private int TempNum;

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
            Random = UnityEngine.Random.Range(1, 6);

            if (Random == TempNum)
            {
                OnMonsterSummon();
                Debug.Log("Same Monster, CHANGED");
            }
            else
            {
                Instantiate(MonsterList[Random - 1], this.transform.position, quaternion.identity);
                Random = TempNum;
            }
        }
    }
}
