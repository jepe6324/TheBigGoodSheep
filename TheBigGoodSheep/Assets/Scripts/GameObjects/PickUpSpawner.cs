using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject iceCube;
	public GameObject rainbowPickup;
	public GameObject obstacle;

	public float spawnFreqRangeLow;
	public float spawnFreqRangeHigh;


	private int count;
	void Start()
	{
		count = 0;
		StartCoroutine(StartSpawning());
	}

	IEnumerator StartSpawning()
	{

		yield return new WaitForSeconds(Random.Range(spawnFreqRangeLow, spawnFreqRangeLow));
		if (count % 4 == 0)
			Instantiate(obstacle, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
		else if (count % 10 == 0)
			Instantiate(rainbowPickup, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
		else
			Instantiate(iceCube, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

		count++;
		
		StartCoroutine(StartSpawning());
	}
}
