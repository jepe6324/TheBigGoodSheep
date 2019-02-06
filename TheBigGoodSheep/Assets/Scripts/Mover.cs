using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	Rigidbody2D myRigidbody;
	public float speed;
	public float lifeTime;

	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myRigidbody.velocity = transform.right * speed;
	}

	void Update()
	{
		lifeTime--;
		if (lifeTime <= 0)
			Destroy(this.gameObject);
	}
}
