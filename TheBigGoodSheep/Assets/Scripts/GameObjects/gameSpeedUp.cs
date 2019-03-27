using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameSpeedUp : MonoBehaviour
{
	public float speedIncreaseFactor;
	public float scoreThreshold;

	private int hiddenScore;

	void Start()
	{
		EnemyStats.enemySpeed = EnemyStats.startSpeed;
	}

	void Update()
	{
		if (hiddenScore >= scoreThreshold)
		{
			hiddenScore = 0;

			EnemyStats.enemySpeed += speedIncreaseFactor;
		}
	}

	void IncrementHiddenScore()
	{
		hiddenScore += 100;
	}
}
