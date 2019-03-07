using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public float xDeathPos;
	private string leftOrRight; // This will be set at spawn to deduce weather the object is moving to the right or left.

    void Start()
	{
        if (transform.position.x > xDeathPos)
		{
			leftOrRight = "Left";
		}
		else
			leftOrRight = "Right";
	}

	void Update()
	{
		if (transform.position.x <= xDeathPos && leftOrRight == "Left")
		{
			gameObject.BroadcastMessage("BeforeDestruction"); // Hopefully this will let me run a line of code before the object gets destroyed.
			Destroy(this.gameObject);
		}
		else if (transform.position.x >= xDeathPos && leftOrRight == "Right")
		{
			Destroy(this.gameObject);
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag("Sheep") && gameObject.tag == "IceCream")
		{
           
            //AudioSource.PlayClipAtPoint(killSound, new Vector2(0, 0), 1.0f); // This line could be repurposed as a hit sound.
			//Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); // This line could be repurposed as a hit effect
			Destroy(this.gameObject);
        }
		else
			return;
	}

	void BeforeDestruction()
	{

	}
}
