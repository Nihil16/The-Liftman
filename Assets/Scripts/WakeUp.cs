using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    private float tran;
    private float transparency;

    private float StartTran = 1;
    private float EndTran = 0;


    void Start()
    {
        LeanTween.value(StartTran, EndTran, 6).setOnUpdate(SetTran);
        
    }
    public void SetTran(float tran)
    {
        transparency = tran;
        //Debug.Log(tran);
        Debug.Log(transparency);
        Tran();
    }
    public void Tran()
    {
        this.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 0.0f, transparency);
    }

    



    // Update is called once per frame

}
