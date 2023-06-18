using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorNoiseManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip[] Sounds;
    public static bool CorrectFloor;
    public bool MonsterSpawning = true;

    private void OnEnable()
    {
        GameEvents.OnArriveDelegate += OnArriveDelegate;
    }

    private void OnDisable()
    {
        GameEvents.OnArriveDelegate -= OnArriveDelegate;
    }
    private void OnArriveDelegate()
    {

        if (MonsterSpawning == true)
        {

            AudioSource.clip = Sounds[0];
            if (CorrectFloor == true)
            {
                AudioSource.pitch = 1f;
            }
            if (CorrectFloor == false)
            {
                AudioSource.pitch = 0.5f;
            }

            AudioSource.Play();
            MonsterSpawning = false;

        }
        else
        {
            AudioSource.pitch = 0.5f;
            AudioSource.clip = Sounds[1];
            AudioSource.Play();
            MonsterSpawning = true;
        }


    }

}
