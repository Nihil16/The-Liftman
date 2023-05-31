using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject RoofObject;
    public List<GameObject> ButtonObjects;
    public Light RoofLight;
    public Light ButtonLight;
    public List<Material> Materials;

    private bool flicking = false;

    public float Timer = 0f;

    private void OnEnable()
    {
        GameEvents.OnFlicker += OnFlicker;
    }

    private void OnDisable()
    {
        GameEvents.OnFlicker -= OnFlicker;
    }

    public void OnFlicker(int Num)
    {
        flicking = true;

        StartCoroutine(Flicker());
        StartCoroutine(Counter(Num));
    }

    public IEnumerator Flicker()
    {
        while (flicking == true)
        {
            Off();
            float RandomOn = UnityEngine.Random.Range(0.01f, 0.5f);
            yield return new WaitForSeconds(RandomOn);

            On();
            float RandomOff = UnityEngine.Random.Range(0.01f, 0.5f);
            yield return new WaitForSeconds(RandomOff);
        }

    }

    public IEnumerator Counter(int Num)
    {
        yield return new WaitForSeconds(Num);
        flicking = false;
    }


    public void Off()
    {
        RoofLight.enabled = false;
        ButtonLight.enabled = false;
        RoofObject.GetComponent<MeshRenderer>().material = Materials[0];
        foreach (GameObject button in ButtonObjects)
        {
            button.GetComponent<MeshRenderer>().material = Materials[0];
        }
    }

    public void On()
    {
        RoofLight.enabled = true;
        ButtonLight.enabled = true;
        RoofObject.GetComponent<MeshRenderer>().material = Materials[1];
        foreach (GameObject button in ButtonObjects)
        {
            button.GetComponent<MeshRenderer>().material = Materials[1];
        }
    }


}
