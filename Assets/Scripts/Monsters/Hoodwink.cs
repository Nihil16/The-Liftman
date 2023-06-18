using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoodwink : MonoBehaviour
{
    public List<GameObject> NumberList;
    public List<Transform> PostionList;
    public GameObject Spawnable;

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
        Spawnable.transform.parent = null;

        GenorateNumber();

        StartCoroutine(Loop());

    }
    private IEnumerator Loop()
    {

        for (int i = 0; i < 3; i++)
        {
            LeanTween.rotateAround(gameObject, Vector3.up, 360, 2.5f);
            yield return new WaitForSeconds(4f);
            GenorateNumber();
        }

    }

    private void GenorateNumber()
    {
        GameEvents.OnDestroy?.Invoke();
        int Random = UnityEngine.Random.Range(0, 9);
        Instantiate(NumberList[PuzzleManager.Solution - 1], PostionList[Random].transform.position, Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)));
    }
}
