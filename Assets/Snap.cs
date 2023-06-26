using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnEnable()
    {
        GameEvents.OnCorySnap += OnCorySnap;
    }
    private void OnDisable()
    {
        GameEvents.OnCorySnap -= OnCorySnap;
    }

    public void OnCorySnap()
    {
        audioSource.Stop();
        float Random = UnityEngine.Random.Range(0.9f, 1.1f);
        audioSource.pitch = Random;
        audioSource.Play();
    }
}
