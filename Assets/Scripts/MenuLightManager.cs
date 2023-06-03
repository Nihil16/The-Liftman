using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLightManager : MonoBehaviour
{
    public GameObject RoofObject;
    public Light RoofLight;

    public List<Material> Materials;

    private bool flicking = false;

    public float Timer = 0f;

    private void Start()
    {
        flicking = true;
        StartCoroutine("Flicker");
    }


    public IEnumerator Flicker()
    {
        while (flicking == true)
        {
            Off();
            float Random1 = UnityEngine.Random.Range(0.01f, 0.5f);
            yield return new WaitForSeconds(Random1);

            On();
            float Random2 = UnityEngine.Random.Range(0.01f, 0.5f);
            yield return new WaitForSeconds(Random2);

            Off();
            float Random3 = UnityEngine.Random.Range(0.01f, 0.5f);
            yield return new WaitForSeconds(Random3);

            On();

            float RandomOff = UnityEngine.Random.Range(4, 10);
            yield return new WaitForSeconds(RandomOff);
        }

    }

    public void Off()
    {
        RoofLight.enabled = false;
        RoofObject.GetComponent<MeshRenderer>().material = Materials[0];
    }

    public void On()
    {
        RoofLight.enabled = true;
        RoofObject.GetComponent<MeshRenderer>().material = Materials[1];

    }


}

