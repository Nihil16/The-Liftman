using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public AudioSource AudioSource;
    private void OnEnable()
    {
        GameEvents.OnButtonPressed += OnButtonPressed;

    }
    private void OnDisable()
    {
        GameEvents.OnButtonPressed -= OnButtonPressed;
    }


    public void OnButtonPressed(int num)
    {
        AudioSource.Play(); 
    }
}
