using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameSpeedUp : MonoBehaviour {


	private int hiddenScore = ScoreVariables.score;

	void Update () {

		for (int i = 1; i < 10; i++) {

			if (hiddenScore == 1500)
			{
				hiddenScore = 0;

				EnemyStats.enemySpeed += 0.1f;
		}
	}
}
}
