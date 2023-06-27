using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorNoiseManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip[] Sounds;
    public static bool CorrectFloor;
    public bool MonsterSpawning = true;

    public static bool intro = true;
    private void OnEnable()
    {
        GameEvents.OnArrive += OnArriveDelegate;
    }

    private void OnDisable()
    {
        GameEvents.OnArrive -= OnArriveDelegate;
    }
    private void OnArriveDelegate()
    {
        AudioSource.pitch = 0.5f;
        AudioSource.clip = Sounds[1];
        AudioSource.Play();

    }

}
