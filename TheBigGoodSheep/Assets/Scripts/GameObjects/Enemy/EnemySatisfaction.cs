using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySatisfaction : MonoBehaviour {

	public Sprite satisfiedSprite;
    public AudioClip MusicClip;
    public AudioSource MusicSource;

	private SpriteRenderer mySpriteRenderer;
	private BoxCollider2D myCollider;
	private bool satisfaction;

	// Use this for initialization
	void Start () {

        satisfaction = false;
		mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		myCollider = GetComponentInChildren<BoxCollider2D>();
        MusicSource.clip = MusicClip;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "IceCream")
		{
			mySpriteRenderer.sprite = satisfiedSprite;
			satisfaction = true;
			Destroy(myCollider);
            MusicSource.Play();
		}
	}
}
