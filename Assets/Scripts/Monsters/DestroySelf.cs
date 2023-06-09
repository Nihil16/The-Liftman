using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnButtonPressed += OnButtonPressed;
        GameEvents.OnDestroy += OnDestroy;
    }
    private void OnDisable()
    { 
        GameEvents.OnButtonPressed -= OnButtonPressed;
        GameEvents.OnDestroy -= OnDestroy;

    }

    public void OnButtonPressed(int Answer)
    {
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

}
