using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemode : MonoBehaviour {

	public int iceCreamTimer;
	public int iceCubeValue;

	private int frames;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		frames++; // Every frame we increment the frame counter

		if (frames == 60) // When the frame counter reaches 60 a whole second has passed
		{
			iceCreamTimer--;	// Remove one second from the icecream timer
			frames = 0;			// Reset the frame counter to 0 again so that we can start counting on the second
			if (iceCreamTimer == 0)
			{
				SceneManager.LoadScene("GameOver"); // If the icecream timer reaches 0 we lose
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "IceCube") // Checks the other objects tag to see if it is a "IceCube"
		{ // If it is do the things that it should do when getting into contact with an IceCube
			Destroy(other.gameObject);
			iceCreamTimer += iceCubeValue;
			frames = 0;
			return;
		}
		else
		{
			return;
		}
	}
}
