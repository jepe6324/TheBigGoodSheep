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
        if (transform.position.x <= xDeathPos && leftOrRight == "Left") // If the timer reaches 0 the icecream despawns
        
            Destroy(this.gameObject);
            
        


        else if (transform.position.x >= xDeathPos && leftOrRight == "Right")
        {
            Destroy(this.gameObject);

        }
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag("Sheep"))
		{
           
            //AudioSource.PlayClipAtPoint(killSound, new Vector2(0, 0), 1.0f); // This line could be repurposed as a hit sound.
			//Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); // This line could be repurposed as a hit effect
			Destroy(this.gameObject);
            

        }
		else
			return;
	}
}
