using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Follow;
    public float Y;
    
    void Update()
    {
        Y = Follow.transform.localEulerAngles.y;
        LeanTween.rotateY(gameObject, Y, 0);



    }
}
