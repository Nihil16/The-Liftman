using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpVoices : MonoBehaviour
{
    public AudioSource AudioS;
    private void OnEnable()
    {
        GameEvents.OnReceiveVoice += OnReceiveVoice;
    }

    private void OnDisable()
    {
        GameEvents.OnReceiveVoice -= OnReceiveVoice;
    }

    public void OnReceiveVoice(AudioClip Audio)
    {
        AudioS.clip = Audio;
        AudioS.Play();
    }
}
