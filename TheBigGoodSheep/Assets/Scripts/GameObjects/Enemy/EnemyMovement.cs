using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float startSpeed;
	public float minY;
	public float maxY;

	static private bool firstSheep = true;
	
	enum EnemyState
	{
		MOVING_UP,
		MOVING_DOWN,
		SATISFIED
	}

	private EnemyState enemyState;

	void Start()
	{
		if (Random.value > 0.5f)
			enemyState = EnemyState.MOVING_UP;
		else
			enemyState = EnemyState.MOVING_DOWN;

		if (firstSheep == true)
		{
			EnemyStats.enemySpeed = startSpeed;
			firstSheep = false;
		}
	}

	void Update () {

		switch (enemyState)
		{
			case EnemyState.SATISFIED:
				this.transform.Translate(new Vector3(startSpeed * Time.deltaTime, 0, 0));
				break;

			default:
				this.transform.Translate(new Vector3(EnemyStats.enemySpeed * Time.deltaTime, 0, 0));
				break;
		}
		switch (enemyState) // Vertical movement
		{
			case EnemyState.MOVING_UP:
				this.transform.Translate(new Vector3(0, Time.deltaTime, 0));
				if (this.transform.position.y >= maxY)
				{
					enemyState = EnemyState.MOVING_DOWN;
				}
				break;
			case EnemyState.MOVING_DOWN:
				this.transform.Translate(new Vector3(0, -Time.deltaTime, 0));
				if (this.transform.position.y <= minY)
				{
					enemyState = EnemyState.MOVING_UP;
				}
				break;
			case EnemyState.SATISFIED:
				MoveOffScreen();
				break;
		} // Vertical movement
	}

	void MoveOffScreen()
	{
		if (this.transform.position.y > -4 && this.transform.position.y < 0)
			this.transform.Translate(new Vector3(0, -Time.deltaTime * 6, 0));
		else if (this.transform.position.y < 3 && this.transform.position.y > 0)
			this.transform.Translate(new Vector3(0, Time.deltaTime * 6, 0));
	}

	void setSatisfied()
	{
		enemyState = EnemyState.SATISFIED;
	}
}

public class EnemyStats
{
	static public float enemySpeed;
}