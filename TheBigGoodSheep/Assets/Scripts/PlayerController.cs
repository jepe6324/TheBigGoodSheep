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
	Rigidbody2D rigidbody2d;

	public GameObject iceCream;
	public Transform iceCreamSpawn;
	public float fireRate;
	private float nextFire;

	// Use this for initialization
	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate(iceCream, iceCreamSpawn.position, iceCreamSpawn.rotation);
		}
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		movement.x *= speedX;
		movement.y *= speedY;
		rigidbody2d.velocity = movement;


		//if (moveHorizontal != 0)
		//	Debug.Log(movement.x * speedX);
		//if (moveVertical != 0)
		//	Debug.Log(movement.y * speedY);

		rigidbody2d.position = new Vector2(
			Mathf.Clamp(rigidbody2d.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(rigidbody2d.position.y, boundary.yMin, boundary.yMax));
	}
}
