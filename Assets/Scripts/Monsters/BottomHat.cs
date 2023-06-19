using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BottomHat : MonoBehaviour
{
    public GameObject Hat;
    public List<GameObject> Spawnables;
    public GameObject Spawnpoint;
    private void OnEnable()
    {
        GameEvents.OnDisplayPuzzle += OnDisplayPuzzle;
    }

    private void OnDisable()
    {
        GameEvents.OnDisplayPuzzle -= OnDisplayPuzzle;
    }
    public void OnDisplayPuzzle()
    {
        StartCoroutine(Rabbit(PuzzleManager.Solution));
    }

    private IEnumerator Rabbit(int Soloution)
    {
        if (Hat != null)
        {


            yield return new WaitForSeconds(1);
            LeanTween.move(Hat, new Vector3(0, -2.135f, 0), 0.2f);
            Hat.transform.parent = null;
            yield return new WaitForSeconds(2);
            for (int i = 0; i < Soloution; i++)
            {
                Instantiate(Spawnables[0], Spawnpoint.transform.position, quaternion.identity);
                yield return new WaitForSeconds(1.2f);
            }
        }





    }

}
