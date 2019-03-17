using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float startSpeed;
	public float minY;
	public float maxY;

	private bool topBool; // This keeps track of weather the last thing the sheep touched was the top or bottom of the road.

	void Start()
	{
		if (Random.value > 0.5f)
			topBool = true;
		else
			topBool = false;

		EnemyStats.enemySpeed = startSpeed;
	}

	void Update () {

		{// Horizontal movement
			this.transform.Translate(new Vector3(EnemyStats.enemySpeed * Time.deltaTime, 0, 0));
		}// Horizontal movement

		{//Vertical movement
			if (topBool == true)
			{
				this.transform.Translate(new Vector3(0, -Time.deltaTime, 0)); // The sheep touched the top last, so move down
			}
			else
				this.transform.Translate(new Vector3(0, Time.deltaTime, 0));  // The sheep touched the bottom last, so move up
		}//Vertical movement

		if (this.transform.position.y >= maxY)
		{
			topBool = true;
		}
		if (this.transform.position.y <= minY)
		{
			topBool = false;
		}
	}
}

public class EnemyStats
{
	static public float enemySpeed;
}