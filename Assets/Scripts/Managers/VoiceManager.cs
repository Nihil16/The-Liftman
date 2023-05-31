using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class VoiceManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public static bool IsTalking;
    private int CurrentID;



    public AudioClip[] IntroAL;



    void Awake()
    {

      // StartCoroutine(PlayVoiceLine(2, 0));

    }



    private void OnEnable()
    {
        GameEvents.OnButtonPressed += OnButtonPressed;
    }

    private void OnDisable()
    {
        GameEvents.OnButtonPressed -= OnButtonPressed;
    }

    private void OnButtonPressed(int Number)
    {

    }

    private IEnumerator PlayVoiceLine(int BeforeSeconds, int ID)
    {
        Debug.Log("Play Voice Line" + ID);
        AudioSource.Pause();
        CurrentID = ID;
        AudioSource.clip = IntroAL[ID];

        yield return new WaitForSeconds(BeforeSeconds);
        IsTalking = true;

        AudioSource.Play();

        AudioClip clip = AudioSource.clip;

        yield return new WaitForSeconds(clip.length);
        Debug.Log("Finishing Voice Line" + ID);
        VoiceDone(ID);

    }

    private void VoiceDone(int ID)
    {
        StopAllCoroutines();
        switch (ID)
        {
            case 0: //After 10 Seconds Plays "Pick a Button"
                {
                    StartCoroutine(PlayVoiceLine(10, 1));
                    break;
                }


        }
    }
}
