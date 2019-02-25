using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemode : MonoBehaviour {

	public int iceCreamTimer;
	public int iceCubeValue;

	public int rainbowTimer;
	public int rainbowDuration;

	public int obstaclePenalty;

	public Text timerText;
	public Text scoreText;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    private int iceCreamFrames;
	private int rainbowFrames;
	// Use this for initialization
	void Start () {
		ApplicationModel.score = 0;
        MusicSource.clip = MusicClip;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

		iceCreamFrames++; // Every frame we increment the frame counter

		if (rainbowTimer > 0)
		{
			rainbowFrames++;

			if (rainbowFrames == 60)
			{
				rainbowTimer--;
				rainbowFrames = 0;
			}
		}
		else if (iceCreamFrames == 60) // When the frame counter reaches 60 a whole second has passed
		{
			iceCreamTimer--;	// Remove one second from the icecream timer
			iceCreamFrames = 0;			// Reset the frame counter to 0 again so that we can start counting on the second
			if (iceCreamTimer <= 0)
			{
				SceneManager.LoadScene("GameOver"); // If the icecream timer reaches 0 we lose
			}
		}

		

		timerText.text = "" + iceCreamTimer;
		scoreText.text = "" + ApplicationModel.score;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "IceCube") // Checks the other objects tag to see if it is a "IceCube"
		{ // If it is do the things that it should do when getting into contact with an IceCube
			Destroy(other.gameObject);
            MusicSource.Play();
            iceCreamTimer += iceCubeValue;
			iceCreamFrames = 0;
		}
		else if (other.tag == "Rainbow")
		{
			Destroy(other.gameObject);
			rainbowTimer += rainbowDuration;
			rainbowFrames = 0;
		}
		else if (other.tag == "Obstacle")
		{
			Destroy(other.gameObject);
			iceCreamTimer -= obstaclePenalty;
			iceCreamFrames = 0;
		}
	}

	void SheepSatisfied() // This should be called when a sheep is fed with the right color
	{
		ApplicationModel.score += 100;
	}

	void SheepUnsatisfied() // This should be called when a sheep is fed with the wrong color, or not at all.
	{
		ApplicationModel.score -= 50;
	}
}

public class ApplicationModel
{
	static public int score = 0;    // this is reachable from everywhere
}