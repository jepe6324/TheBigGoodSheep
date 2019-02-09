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
		frames++;

		if (frames == 60)
		{
			iceCreamTimer--;
			frames = 0;
			if (iceCreamTimer == 0)
			{
				SceneManager.LoadScene("GameOver");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(this.tag + " is colliding with: " + other.tag); // TODO: Remove this debug line
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
