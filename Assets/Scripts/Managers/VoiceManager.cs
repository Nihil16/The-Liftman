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

    }

    private void OnPlayAudio(int Num)
    {
        //StartCoroutine(PlayVoiceLine(0, Num));
    }





    private IEnumerator PlayVoiceLine(int BeforeSeconds, int ID)
    {
        AudioSource.Pause();

        CurrentID = ID;
        AudioSource.clip = IntroAL[ID];

        yield return new WaitForSeconds(BeforeSeconds);

        IsTalking = true;
        AudioSource.Play();

        AudioClip clip = AudioSource.clip;
        yield return new WaitForSeconds(clip.length);

        Debug.Log("Finishing Voice Line" + ID);
    }
}
