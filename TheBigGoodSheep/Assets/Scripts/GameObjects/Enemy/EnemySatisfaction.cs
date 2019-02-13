using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySatisfaction : MonoBehaviour {

	private SpriteRenderer mySpriteRenderer;
	private BoxCollider2D myCollider;
	public Sprite satisfiedSprite;

	// Use this for initialization
	void Start () {
		mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		myCollider = GetComponentInChildren<BoxCollider2D>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "IceCream")
		{
			mySpriteRenderer.sprite = satisfiedSprite;
			Destroy(myCollider);
		}
	}
}
