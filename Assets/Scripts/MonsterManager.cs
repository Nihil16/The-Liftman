using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> MonsterList;


    private void OnEnable()
    {
        GameEvents.OnMonsterSummon += OnMonsterSummon;
    }
    private void OnDisable()
    {
        GameEvents.OnMonsterSummon -= OnMonsterSummon;
    }

    private void Start()
    {
        Instantiate(MonsterList[0], this.transform.position, Quaternion.Euler(0, 220, 0));

    }

    void OnMonsterSummon()
    {
        //int Random = UnityEngine.Random.Range(0, 2);
        //if (Random == 0) Instantiate(MonsterList[0], new Vector3(0, 0, 0), Quaternion.identity);
        //else if (Random == 1) Instantiate(MonsterList[1]);
        //else if (Random == 2) Instantiate(MonsterList[2]);

       GameEvents.OnHeartbeat?.Invoke(5);



    }





}
