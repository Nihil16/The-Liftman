using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public float StartRotation;

   // [Range (0f, 1f)]
    public float StartPositon;

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


    private void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, StartRotation, transform.rotation.z));

        //Smiley Start = 143
        //Mr Gloom = 180
        //



        //Smiley = 187
        //Bottom Hat = 142
        //Mr Gloom = 220



        transform.position = (new Vector3(transform.position.x, StartPositon, transform.position.z));
    }


    public void Arrived()
    {
        int Random = UnityEngine.Random.Range(2, 6);
        GameEvents.OnOpenDoor?.Invoke(Random, false);

        int Soloution = UnityEngine.Random.Range(1, 9);
        GameEvents.OnDisplayPuzzle?.Invoke(Soloution);

        GameEvents.OnLockButton.Invoke(false);
    }
    



    public void OnPuzzleComplete()
    {
        var temp = StartCoroutine(Puzzle());
    }


    private IEnumerator Puzzle()
    {
        int Random = UnityEngine.Random.Range(5, 10);
        LeanTween.move(gameObject, new Vector3(-3.5f, 0, 0), Random).setEaseInQuint();
        yield return new WaitForSeconds(Random + 1);

        int DoorClose = UnityEngine.Random.Range(3, 6);
        GameEvents.OnOpenDoor?.Invoke(DoorClose, false);

        yield return new WaitForSeconds(DoorClose + 1);
        MonsterManager.MonsterHere = false;

        GameEvents.OnRandomFloor?.Invoke();

        Destroy(gameObject);
    }
}
