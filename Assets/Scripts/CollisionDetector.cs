using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public int FloorNumber;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.OnFloorDetects?.Invoke(FloorNumber);
    }

}
