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

		Vector3 tilePosition = transform.position; // The relative X position of tile[0] should be == 0
		tilePosition.x = tileSize;
		tilePosition.y = 0;

		for (int i = 0; i < tiles.Length; i++)
		{
			tiles[i].transform.localPosition = tilePosition * i;
		}

		resetPos = transform.position;

		Debug.Log(resetPos);
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
