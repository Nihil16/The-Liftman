using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnButtonPressed += OnButtonPressed;
    }
    private void OnDisable()
    { 
        GameEvents.OnButtonPressed -= OnButtonPressed;
    }

    public void OnButtonPressed(int Answer)
    {
        Destroy(gameObject);
    }
}
