using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smiley : MonoBehaviour
{
    public List<GameObject> Teeth;
    public Animator myAnim;

    public List<AudioClip> AudioClips;

    public GameObject Key;

    private int Random;
    public static bool Ending;

    private void OnEnable()
    {
        GameEvents.OnDisplayPuzzle += OnDisplayPuzzle;
        GameEvents.OnButtonPressed += OnButtonPressed;
    }

    private void OnDisable()
    {
        GameEvents.OnDisplayPuzzle -= OnDisplayPuzzle;
        GameEvents.OnButtonPressed -= OnButtonPressed;
    }
    private void Start()
    {
        Key.SetActive(false);

        if (Ending == true)
        {
            Key.SetActive(true);
        }

        Random = UnityEngine.Random.Range(1, 9);

        while (Random == PuzzleManager.Solution)
        {
            Random = UnityEngine.Random.Range(1, 9);
        }

        for (int i = 0; i < Teeth.Count; i++)
        {
            Teeth[i].SetActive(false);
        }

        for (int i = 0; i < Random; i++)
        {
            Teeth[i].SetActive(true);
        }
    }



    public void OnDisplayPuzzle()
    {

        GameEvents.OnReceiveVoice?.Invoke(AudioClips[PuzzleManager.Solution-1]);


        StartCoroutine(Open(PuzzleManager.Solution));
    }

    private IEnumerator Open(int Soloution)
    {
        

        if (Ending == true)
        {
            myAnim.SetTrigger("MouthOpen");
            yield return new WaitForSeconds(1f);
            myAnim.speed = 0;

        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                myAnim.SetTrigger("MouthOpen");
                yield return new WaitForSeconds(4f);
            }
        }
        
    }

    private void OnButtonPressed(int Answer)
    {
        Debug.Log("BUTTON PRESSED");
        if (Answer == PuzzleManager.Solution)
        {                                    
            Debug.Log("GOOD WORK");          
        }
        if(Answer == Random)
        {
            Ending = true;
        }

    }


}
