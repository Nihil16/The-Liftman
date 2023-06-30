using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using static GameEvents;

public class FloorNumber : MonoBehaviour
{
    public AudioSource AudioS;
    public AudioClip clip;

    public static int Moving;
    public static int NumberofFloor;

    public GameObject Up;
    public GameObject Down;

    public TextMeshProUGUI Number;

    public List<string> NO;
    private void OnEnable()
    {
        GameEvents.OnFloorDetects += OnFloorDetects;
        GameEvents.OnNotMoving += OnNotMoving;
    }

    private void OnDisable()
    {
        GameEvents.OnFloorDetects -= OnFloorDetects;
        GameEvents.OnNotMoving -= OnNotMoving;
    }
    private void Start()
    {
        
    }
    private void OnFloorDetects(int floor)
    {
        
        Number.text = (floor.ToString());
        NumberofFloor = floor;
        if (Moving == 0)
        {
            Up.SetActive(false);
            Down.SetActive(false);
        }
        else if (Moving == 1)
        {
            Up.SetActive(true);
            Down.SetActive(false);
            AudioS.Play();
        }
        else if (Moving == 2) 
        { 
        
            Up.SetActive(false);
            Down.SetActive(true);
            AudioS.Play();
        }


    }

    public void OnNotMoving()
    {
        Up.SetActive(false);
        Down.SetActive(false);
    }




}
