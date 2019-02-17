using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject pickup;

	public float spawnFreqRangeLow;
	public float spawnFreqRangeHigh;

	void Start()
	{

		StartCoroutine(StartSpawning());
	}

	IEnumerator StartSpawning()
	{

		yield return new WaitForSeconds(Random.Range(spawnFreqRangeLow, spawnFreqRangeLow));
		Instantiate(pickup, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);


		StartCoroutine(StartSpawning());
	}
}
