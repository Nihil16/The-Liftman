using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnEnable()
    {
        GameEvents.OnPuzzleComplete += OnPuzzleComplete;
    }

    private void OnDisable()
    {
        GameEvents.OnPuzzleComplete -= OnPuzzleComplete;
    }


    void Start()
    {
        MonsterManager.MonsterHere = true;
        int Random = UnityEngine.Random.Range(5, 10);
        LeanTween.move(this.gameObject, new Vector3 (0,0,0), Random).setEaseInQuint().setOnComplete(this.Arrived);;

    }

    public void Arrived()
    {
        int Random = UnityEngine.Random.Range(2, 6);
        GameEvents.OnOpenDoor?.Invoke(Random, false);

        GameEvents.OnLockButton.Invoke(false);
    }
    



    public void OnPuzzleComplete()
    {
        var temp = StartCoroutine(Puzzle());
    }


    private IEnumerator Puzzle()
    {
        int Random = UnityEngine.Random.Range(5, 10);
        if (gameObject  != null)
        {
            LeanTween.move(gameObject, new Vector3(-3.5f, 0, 0), Random).setEaseInQuint();
        }
        

        yield return new WaitForSeconds(Random + 1);

        int DoorClose = UnityEngine.Random.Range(3, 6);
        GameEvents.OnOpenDoor?.Invoke(DoorClose, false);

        yield return new WaitForSeconds(DoorClose + 1);
        MonsterManager.MonsterHere = false;
        GameEvents.OnRandomFloor?.Invoke();
        Destroy(gameObject);
    }
}
