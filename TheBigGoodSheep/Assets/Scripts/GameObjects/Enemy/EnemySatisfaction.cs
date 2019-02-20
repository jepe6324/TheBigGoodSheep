using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySatisfaction : MonoBehaviour {

	public Sprite satisfiedSprite;
    public AudioClip MusicClip;
    public AudioSource MusicSource;

	private SpriteRenderer mySpriteRenderer;
	private BoxCollider2D myCollider;
	private Gamemode myGamemode;
	private bool satisfaction;

	// Use this for initialization
	void Start () {

        satisfaction = false;
		mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		myCollider = GetComponentInChildren<BoxCollider2D>();
        MusicSource.clip = MusicClip;

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
		satisfaction = true;
		Destroy(myCollider);
		MusicSource.Play();

		if (myGamemode != null)
			myGamemode.BroadcastMessage("SheepSatisfied");
		else
			Debug.Log("Cannot find the 'gameObject' script");
	}
}