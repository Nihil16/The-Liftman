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

    public delegate void OnEngineDelegate(int Number);
    public static OnEngineDelegate OnEngine;

    public delegate void OnOpenDoorDelegate(int Time, bool Open);
    public static OnOpenDoorDelegate OnOpenDoor;

    public delegate void OnTurnOffDelegate(int Flicker);
    public static OnTurnOffDelegate OnFlicker;

    public delegate void OnLockButtonDelegate(bool Lock);
    public static OnLockButtonDelegate OnLockButton;

    public delegate void OnRandomFloorDelegate();
    public static OnRandomFloorDelegate OnRandomFloor;

    public delegate void OnPuzzleCompleteDelegate();
    public static OnPuzzleCompleteDelegate OnPuzzleComplete;

    public delegate void OnDisplayPuzzleDelegate();
    public static OnDisplayPuzzleDelegate OnDisplayPuzzle;

    public delegate void OnPlayAudioDelegate(int Num);
    public static OnPlayAudioDelegate OnPlayAudio;

    public delegate void OnDestroyDelegate();
    public static OnDestroyDelegate OnDestroy;

    public delegate void ArriveDelegate();
    public static ArriveDelegate OnArrive;

    public delegate void FloorDetectsDelegate(int Floor);
    public static FloorDetectsDelegate OnFloorDetects;

    public delegate void OnNotMovingDelegate();
    public static OnNotMovingDelegate OnNotMoving;

    public delegate void OnHelpManagerDelegate(int Num);
    public static OnHelpManagerDelegate OnHelpManager;

    public delegate void OnDisplayHelpDelegate();
    public static OnDisplayHelpDelegate OnDisplayHelp;

    public delegate void OnCorySnapDelegate();
    public static OnCorySnapDelegate OnCorySnap;

    public delegate void OnSendVoice(AudioClip clip);
    public static OnSendVoice OnReceiveVoice;

    public delegate void OnMonsterDestroyedDelegate(string Name, MonsterData MonsterData);
    public static OnMonsterDestroyedDelegate OnMonsterDestroyed;
}
