using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject enemySheepRed;
	public GameObject enemySheepYellow;
	public GameObject enemySheepBlue;

	public float spawnFreqRangeLow;
	public float spawnFreqRangeHigh;

	void Start () {

		StartCoroutine (StartSpawning ());
	}
	
	IEnumerator StartSpawning(){
		
		yield return new WaitForSeconds (Random.Range (spawnFreqRangeLow, spawnFreqRangeLow));
		GameObject clone;
		int randomValue = Random.Range(1, 4);
		if (randomValue == 1)
		{
			clone = Instantiate(enemySheepRed, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
			clone.name = "Red";
		}
		else if (randomValue == 2)
		{
			clone = Instantiate(enemySheepYellow, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
			clone.name = "Yellow";
		}
		else if (randomValue == 3)
		{
			clone = Instantiate(enemySheepBlue, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
			clone.name = "Blue";
		}
		StartCoroutine (StartSpawning ());
	}
}
