using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    private int Count = 0;
    public GameObject Text;
    public GameObject Text2;
    private void Start()
    {
        Text.SetActive(true);
        Text2.SetActive(false);
        StartCoroutine(Disable());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Is Pressed");
            Count++;


            if (Count == 1)
            {
                Text.SetActive(false);
                Text2.SetActive(true);
                StopCoroutine(Disable());
                StartCoroutine(Disable());
            }

            if (Count == 2)
            {
                SceneManager.LoadScene(2);
            }
            Debug.Log(Count);
        }
    }

    public IEnumerator Disable()
    {
        yield return new WaitForSeconds(5);
        Text.SetActive(false);
        Text2.SetActive(false);
        Count = 0;
    }

}
