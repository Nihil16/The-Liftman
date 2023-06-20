using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class FloorNumber : MonoBehaviour
{
    public GameObject Up;
    public GameObject Down;

    TextMeshProUGUI Number;

    private void Start()
    {
        Number.text = ("2");
    }


}
