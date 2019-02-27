using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTilePosition : MonoBehaviour
{
	public GameObject[] tiles;

	private float tileSize;
	private Vector3 resetPos;

	// Use this for initialization
	void Start () {
		tileSize = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size.x; // It assumes that all tiles will have the same size in the x direction

		Vector3 tilePosition = transform.position;
		tilePosition.x = tileSize;

		for (int i = 0; i < tiles.Length; i++)
		{
			tiles[i].transform.position = tilePosition * i;
		}

		resetPos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x < -tileSize)
		{
			transform.position = resetPos;
		}
	}
}
