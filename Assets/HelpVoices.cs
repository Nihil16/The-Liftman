using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpVoices : MonoBehaviour
{
    public AudioClip[] Correct;
    public AudioClip[] Wrong;

    public AudioClip[] MrGloom;
    public AudioClip[] Smiley;
    public AudioClip[] BottomHat;
    public AudioClip[] Cory;
    public AudioClip[] Hoodwink;






    private void OnEnable()
    {
        GameEvents.OnPlayAudio += OnPlayAudio;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayAudio -= OnPlayAudio;
    }

    public void OnPlayAudio(int ID)
    {

    }
}
