using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Rigidbody2D myRigidbody;

	public float speed;

	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myRigidbody.velocity = transform.right * speed;
	}
}
