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
    public static float VoiceLine;

    private bool First = true;

    public AudioClip[] IntroAL;

    private void OnEnable()
    {
        GameEvents.OnButtonPressed += OnButtonPressed;
        GameEvents.OnPlayAudio += OnPlayAudio;
    }

    private void OnDisable()
    {
        GameEvents.OnButtonPressed -= OnButtonPressed;
        GameEvents.OnPlayAudio -= OnPlayAudio;
    }

    private void OnButtonPressed(int Number)
    {
        if (First == true)
        {
            StopAllCoroutines();

            StartCoroutine(PlayVoiceLine(0, 2));
            First = false;
        }
    }
    private void Start()
    {
        
            StartCoroutine(PlayVoiceLine(4, 0));
      
        
    }


    private void OnPlayAudio(int ID)
    {
        StartCoroutine(PlayVoiceLine(0, ID));
    }

    private IEnumerator PlayVoiceLine(float BeforeSeconds, int ID)
    {

        AudioSource.Pause();

        CurrentID = ID;
        AudioSource.clip = IntroAL[ID];
        AudioClip clip = AudioSource.clip;
        VoiceLine = clip.length + BeforeSeconds;

        yield return new WaitForSeconds(BeforeSeconds);

        IsTalking = true;
        AudioSource.Play();


        yield return new WaitForSeconds(clip.length);

        Debug.Log("Finishing Voice Line" + ID);

        if (ID == 0)
        {
            GameEvents.OnLockButton?.Invoke(false);
        }
        if (ID == 2)  
        {
            yield return new WaitForSeconds(4);
            StartCoroutine(PlayVoiceLine(0, 3));
            GameEvents.OnRandomFloor?.Invoke();
            MonsterManager.MonsterHere = false;
            DoorManager.DoorOpener = true;
        }



            yield return new WaitForSeconds(10);
        if (ID == 0)
        {
            StartCoroutine(PlayVoiceLine(0, 1));
        }

    }
}
