using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(3);

    }
}