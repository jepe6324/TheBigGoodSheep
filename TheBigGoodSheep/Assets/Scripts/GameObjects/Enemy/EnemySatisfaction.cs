﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySatisfaction : MonoBehaviour {

	public Sprite satisfiedSprite;
    public AudioClip MusicClip;
    public AudioSource MusicSource;

	private SpriteRenderer mySpriteRenderer;
	private BoxCollider2D myCollider;
	private Gamemode myGamemode;
	private bool fed;

	// Use this for initialization
	void Start () {
		mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		myCollider = GetComponentInChildren<BoxCollider2D>();
        MusicSource.clip = MusicClip;
		fed = false;

		GameObject player = GameObject.FindWithTag("Player");

		if (player != null)
			myGamemode = player.GetComponent<Gamemode>();
		else
			Debug.Log("Cannot find 'Player' object!");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "IceCream")
		{
			if (other.name == "Rainbow")
			{
				Satisfied(true);
			}
			else if (other.name == name)
				Satisfied(false);
			else
				NotSatisfied();
			//if (other.name == "Red" && name == "RedSheep")
			//	Satisfied();
			//if (other.name == "Yellow" && name == "YellowSheep")
			//	Satisfied();
			//if (other.name == "Blue" && name == "BlueSheep")
			//	Satisfied();
		}
	}

	void Satisfied(bool rainbow) // added this rainbow bool incase i want to give a special satisfied sprite to sheep that ate rainbow icecream
	{
		mySpriteRenderer.sprite = satisfiedSprite;
		Destroy(myCollider);
		MusicSource.Play();
		fed = true;

		if (myGamemode != null)
			myGamemode.BroadcastMessage("SheepSatisfied");
		else
			Debug.Log("Cannot find the 'gameMode' script");
	}
	
	void NotSatisfied()
	{
		//mySpriteRenderer.sprite = unsatisfiedSprite; // Use this if you want to give the sheep a special sprite when angry
		Destroy(myCollider);
		fed = true;

		if (myGamemode != null)
			myGamemode.BroadcastMessage("SheepUnsatisfied");
		else
			Debug.Log("Cannot find the 'gameMode' script");
	}

	void BeforeDestruction()
	{
		if (fed == false)
			NotSatisfied();
	}
}