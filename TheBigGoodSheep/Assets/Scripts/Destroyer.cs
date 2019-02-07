using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	public float lifeTime;

	void Update()
	{
		lifeTime--;
		if (lifeTime <= 0) // If the timer reaches 0 the icecream despawns
			Destroy(this.gameObject);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
		Destroy(gameObject);

		if (other.gameObject.CompareTag("Sheep"))
		{
			// AudioSource.PlayClipAtPoint(killSound, new Vector2(0, 0), 1.0f); // This line could be repurposed as a hit sound.
			//Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); // This line could be repurposed as a hit effect
			Destroy(gameObject);
		}
	}
}
