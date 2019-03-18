using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySatisfaction : MonoBehaviour {

	public Sprite satisfiedSprite;
    public AudioClip MusicClipKum;
    public AudioSource MusicSourceKum;
    public AudioClip MusicClipShot;
    public AudioSource MusicSourceShot;
    //public AudioClip MusicClipNotHot;
    //public AudioSource MusicSourceNotHot;

    private SpriteRenderer mySpriteRenderer;
	private BoxCollider2D myCollider;
	private Gamemode myGamemode;
	private bool fed;

	// Use this for initialization
	void Start () {
		mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		myCollider = GetComponentInChildren<BoxCollider2D>();
        fed = false;

		GameObject player = GameObject.FindWithTag("Player");

		if (player != null)
			myGamemode = player.GetComponent<Gamemode>();
		else
			Debug.Log("Cannot find 'Player' object!");


		MusicSourceKum.clip = MusicClipKum;
		MusicSourceShot.clip = MusicClipShot;
		//MusicSourceNotHot.clip = MusicClipNotHot;
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
            //MusicSourceNotHot.Play();
        }
	}

	void Satisfied(bool rainbow) // added this rainbow bool incase i want to give a special satisfied sprite to sheep that ate rainbow icecream
	{
		mySpriteRenderer.sprite = satisfiedSprite;
		Destroy(myCollider);
        MusicSourceShot.Play();
        MusicSourceKum.Play();
		fed = true;

		GetComponent<EnemyMovement>().BroadcastMessage("setSatisfied");

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