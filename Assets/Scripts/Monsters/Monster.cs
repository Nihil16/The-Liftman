using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public float StartRotation;
    public float FaceRotation;
    public float EndRotation;

   // [Range (0f, 1f)]
    public static float StartPositon;

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
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, StartRotation, transform.rotation.z));
        MonsterManager.MonsterHere = true;
        int Random = UnityEngine.Random.Range(5, 10);
        LeanTween.move(this.gameObject, new Vector3 (0, StartPositon, 0), Random).setEaseInQuint().setOnComplete(this.Arrived);;

    }


        //START ROTATION
        //MRGLOOM: 160
        //BOTTOMHAT: -230
        //SMILEY: 150
        //CORY: 0
        //HOODWINK: -90
        //TWIRL: 0

        //FACE ROTATION
        //MRGLOOM: 220
        //BOTTOMHAT: -230
        //SMILEY: 180
        //CORY: 40
        //HOODWINK: 40
        //TWIRL: 9930.7, 9702, 9624, 9575

        //END ROTATION
        //MRGLOOM: 0
        //BOTTOMHAT: -10
        //SMILEY: 0
        //CORY: 180
        //HOODWINK: 90
        //TWIRL: 0

       
        
        //START POSITION
        //MRGLOOM: 0
        //BOTTOMHAT: -1.4
        //BOTTOMHAT: 0
        //SMILEY: 0
        //CORY: 0.47
        //HOODWINK: 0
        //TWIRL: 0.47


    public void Arrived()
    {

        int Random = UnityEngine.Random.Range(1, 5);
        GameEvents.OnOpenDoor?.Invoke(Random, false);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, FaceRotation, transform.rotation.z));

        GameEvents.OnDisplayPuzzle?.Invoke();

        GameEvents.OnLockButton.Invoke(false);
    }
    



    public void OnPuzzleComplete()
    {
        var temp = StartCoroutine(Puzzle());
    }


    private IEnumerator Puzzle()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, EndRotation, transform.rotation.z));

        int Random = UnityEngine.Random.Range(8, 12);
        LeanTween.move(gameObject, new Vector3(-10f, 0, 0), Random).setEaseInQuint();
        yield return new WaitForSeconds(Random/1.5f+1);

        int DoorClose = UnityEngine.Random.Range(3, 6);
        GameEvents.OnOpenDoor?.Invoke(DoorClose, false);

        yield return new WaitForSeconds(DoorClose + 1);
        MonsterManager.MonsterHere = false;

        GameEvents.OnRandomFloor?.Invoke();

        Destroy(gameObject);
    }
}
