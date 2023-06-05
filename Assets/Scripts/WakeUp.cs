using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    private float transparency;

    private float StartTran = 1;
    private float EndTran = 0;

    void Start()
    {
        //Goes from Start 1 to 0 over 6 seconds
        LeanTween.value(StartTran, EndTran, 6).setOnUpdate(SetTran);
        //Get the material at the start, isn't working need help on that.
    }

    public void SetTran(float tran)
    {
        //Every frame sends an update 
        //That update equals the desired transparency
        transparency = tran;
        Tran();
    }
    public void Tran()
    {
        //transparency now is less and over 6 seconds will equal 0 and stop
        this.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 0.0f, transparency);
    }
}
