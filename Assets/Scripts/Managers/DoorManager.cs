using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject LeftDoor;
    public GameObject RightDoor;

    public Vector3 Left;
    public Vector3 Right;
    public Vector3 Center;

    public static bool DoorOpener;

    private Vector3 Postion;
    private GameObject Door;
    public int Checker = 0;
    public int Count = 1;

    private void OnEnable()
    {
        GameEvents.OnOpenDoor += OnOpenDoor;

    }
    private void OnDisable()
    {
        GameEvents.OnOpenDoor -= OnOpenDoor;
    }

    public void OnOpenDoor(int Num, bool Open)
    {
        if (DoorOpener == true)
        {


            if (Open == true)
            {
                for (int Count = 1; Count <= 2; Count++)
                {
                    if (Open == true)
                    {
                        if (Count == 1)
                        {
                            Door = LeftDoor;
                            Postion = Left;
                        }
                        if (Count == 2)
                        {
                            Door = RightDoor;
                            Postion = Right;
                        }

                        if (Num < 5) //Fast
                        {
                            int Random = UnityEngine.Random.Range(0, 2);
                            LeanTween.move(Door, Postion, Num).setEaseOutBack().setOnComplete(this.OpenDoorChecker);
                        }
                        else if (Num < 8) //Medium
                        {
                            int Random = UnityEngine.Random.Range(0, 2);
                            LeanTween.move(Door, Postion, Num).setEaseOutBack().setOnComplete(this.OpenDoorChecker);
                        }
                        else if (Num <= 11) //Slow
                        {
                            int Random = UnityEngine.Random.Range(0, 2);
                            LeanTween.move(Door, Postion, Num).setEaseOutBack().setOnComplete(this.OpenDoorChecker);
                        }
                    }
                }

            }

            else if (Open == false)
            {
                for (int Count = 1; Count <= 2; Count++)
                {
                    if (Count == 1)
                    {
                        Door = LeftDoor;
                        Postion = Center;
                    }
                    if (Count == 2)
                    {
                        Door = RightDoor;
                        Postion = Center;
                    }

                    int time = UnityEngine.Random.Range(1, 7);

                    if (time < 2) //Fast
                    {
                        int Random = UnityEngine.Random.Range(0, 2);
                        LeanTween.move(Door, Postion, Num).setEaseOutBack();
                    }
                    else if (time < 6) //Medium
                    {
                        int Random = UnityEngine.Random.Range(0, 2);
                        LeanTween.move(Door, Postion, Num).setEaseOutBack();
                    }
                    else if (time < 8) //Slow
                    {
                        int Random = UnityEngine.Random.Range(0, 2);
                        LeanTween.move(Door, Postion, Num).setEaseOutBack();
                    }
                }
            }


        }


    }

    public void OpenDoorChecker()
    {
        if (Checker == 2)
        {
            Opened();
        }
        else
        {
            Checker++;
        }
    }


    public void Opened()
    {
        Checker = 0;
        //GameEvents.OnMonsterSummon?.Invoke();
    }




}


