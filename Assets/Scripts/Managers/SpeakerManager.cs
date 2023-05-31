using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerManager : MonoBehaviour
{
	public AudioSource audioSource;

	private int sampleDataLength = 1024;


	public float clipLoudness;
	public float[] clipSampleData;

	public GameObject cube;
	public float sizeFactor = 1;

	public float minSize = 75;
	public float maxSize = 125;

	private void Awake()
	{
		clipSampleData = new float[sampleDataLength];
	}
	IEnumerator Start()
	{
		audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
		clipLoudness = 0f;
		foreach (var sample in clipSampleData)
		{
			clipLoudness += Mathf.Abs(sample);
		}


		clipLoudness *= sizeFactor;
		clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
		cube.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
		yield return new WaitForSeconds(0.1f);
		yield return StartCoroutine("Start");
		
	}
	
}



//LeanTween.scale(gameObject, new Vector3(1, 1, 1), 10);


