using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {
	public float speedX;
	public float speedY;
	public Boundary boundary;

	public GameObject iceCream;
	public Transform iceCreamSpawn;
	public float fireRate;

	private float nextFire;
	Rigidbody2D myRigidbody;
	Gamemode myGamemode;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		myGamemode = GetComponent<Gamemode>();
	}
	
	void Update()
	{
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate(iceCream, iceCreamSpawn.position, iceCreamSpawn.rotation);
			myGamemode.iceCreamTimer--;
		}
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		movement.x *= speedX;
		movement.y *= speedY;
		myRigidbody.velocity = movement;


		//if (moveHorizontal != 0)
		//	Debug.Log(movement.x * speedX);
		//if (moveVertical != 0)
		//	Debug.Log(movement.y * speedY);

		myRigidbody.position = new Vector2(
			Mathf.Clamp(myRigidbody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(myRigidbody.position.y, boundary.yMin, boundary.yMax));
	}
}
