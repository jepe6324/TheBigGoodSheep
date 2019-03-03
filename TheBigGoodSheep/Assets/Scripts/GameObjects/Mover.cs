using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;


	void Update()
	{
		this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
	}
}
