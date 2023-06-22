using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnEnable()
    {
        GameEvents.OnButtonPressed += OnButtonPressed;
        GameEvents.OnNotMoving += OnNotMoving;
    }

    private void OnDisable()
    {
        GameEvents.OnButtonPressed -= OnButtonPressed;
        GameEvents.OnNotMoving -= OnNotMoving;
    }

    public void OnButtonPressed(int num)
    {
        audioSource.Play();
    }

    public void OnNotMoving()
    {
        audioSource.Stop();
    }



}
