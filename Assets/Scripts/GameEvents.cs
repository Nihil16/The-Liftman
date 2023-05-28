using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void OnButtonPressedDelegate(int Number);
    public static OnButtonPressedDelegate OnButtonPressed;

    public delegate void OnPlaySoundDelegate(int ID);
    public static OnPlaySoundDelegate OnPlaySound;

    public delegate void OnMonsterSummonDelegate();
    public static OnMonsterSummonDelegate OnMonsterSummon;

    public delegate void OnMonsterLeftDelegate();
    public static OnMonsterLeftDelegate OnMonsterLeft;

    public delegate void OnHeartbeatDelegate(int RandomNumber);
    public static OnHeartbeatDelegate OnHeartbeat;

    public delegate void OnOpenDoorDelegate(int Time, bool Open);
    public static OnOpenDoorDelegate OnOpenDoor;

    public delegate void OnTurnOffDelegate(int Flicker);
    public static OnTurnOffDelegate OnFlicker;

    public delegate void OnLockButtonDelegate(bool Lock);
    public static OnLockButtonDelegate OnLockButton;

    public delegate void OnRandomFloorDelegate();
    public static OnRandomFloorDelegate OnRandomFloor;

}