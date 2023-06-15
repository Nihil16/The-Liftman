using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomHatSpawnables : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(-0.2f,0.2f), 1, Random.Range(-0.2f,0.2f)), ForceMode.Impulse) ;
    }
}
