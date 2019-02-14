using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemode : MonoBehaviour {

	public int iceCreamTimer;
	public int iceCubeValue;
	public Text timerText;
	public Text scoreText;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    private int frames;
	private int score;
	// Use this for initialization
	void Start () {
		score = 0;
        MusicSource.clip = MusicClip;
    }
	
	// Update is called once per frame
	void Update () {

		frames++; // Every frame we increment the frame counter

		if (frames == 60) // When the frame counter reaches 60 a whole second has passed
		{
			iceCreamTimer--;	// Remove one second from the icecream timer
			frames = 0;			// Reset the frame counter to 0 again so that we can start counting on the second
			if (iceCreamTimer <= 0)
			{
				SceneManager.LoadScene("GameOver"); // If the icecream timer reaches 0 we lose
			}
		}

		timerText.text = "" + iceCreamTimer;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "IceCube") // Checks the other objects tag to see if it is a "IceCube"
		{ // If it is do the things that it should do when getting into contact with an IceCube
			Destroy(other.gameObject);
            MusicSource.Play();
            iceCreamTimer += iceCubeValue;
			frames = 0;
			return;
		}
		else
		{
			return;
		}
	}

	void SheepSatisfied() // This should be called when a sheep is fed with the right color
	{
		score += 100;
	}

	void SheepUnsatisfied() // This should be called when a sheep is fed with the wrong color, or not at all.
	{
		score -= 50;
	}
}
