using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int Number;
    public Vector3 NewPos;
    public static bool pressed;



    private void OnEnable()
    {
        GameEvents.OnLockButton += OnLockButton;

    }
    private void OnDisable()
    {
        GameEvents.OnLockButton -= OnLockButton;
    }



    private void Start()
    {
        NewPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (Number != ElavatorManager.CurrentFloor && pressed == false)
        {
            pressed = true;
            NewPos = new Vector3(NewPos.x, NewPos.y, NewPos.z - 0.015f);
            GameEvents.OnButtonPressed?.Invoke(Number);
            if (MonsterManager.MonsterHere == true)
            {
                GameEvents.OnPuzzleComplete?.Invoke();
            }
            LeanTween.move(gameObject, NewPos, 0.2f).setEaseOutCubic().setOnComplete(this.Unpress);
            
        }

    }


    public void Unpress()
    {
        NewPos = new Vector3(NewPos.x, NewPos.y, NewPos.z + 0.015f);
        LeanTween.move(gameObject, NewPos, 0.2f).setEaseOutCubic();
        
    }


    public void OnLockButton(bool Locked)
    {
        if (Locked == true)
        {
            pressed = true;
        }
        if (Locked == false)
        {
            pressed = false;
        }

    }

}
