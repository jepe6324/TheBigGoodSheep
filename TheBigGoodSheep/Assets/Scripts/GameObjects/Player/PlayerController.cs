using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {
	public float speedX;
	public float speedY;
	public float fireRate;

	public Boundary boundary;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

	public GameObject iceCream;
	public Transform iceCreamSpawn;

	public Sprite redIceCream;
	public Sprite yellowIceCream;
	public Sprite blueIceCream;
	public Sprite rainbowIceCream;

	private Sprite chosenIceCream;
	private float nextFire;
	private string color;
	Rigidbody2D myRigidbody;
	Gamemode myGamemode;

	// Use this for initialization
	void Start () {
		chosenIceCream = yellowIceCream;
		color = "Yellow";
		myRigidbody = GetComponent<Rigidbody2D>();
		myGamemode = GetComponent<Gamemode>();
        MusicSource.clip = MusicClip;
    }
	
	void Update()
	{
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) // Shoting code
		{
			if (myGamemode.rainbowTimer > 0)
			{
				nextFire = Time.time + fireRate;
				GameObject clone = Instantiate(iceCream, iceCreamSpawn.position, iceCreamSpawn.rotation);

				clone.GetComponentInChildren<SpriteRenderer>().sprite = rainbowIceCream;
				clone.name = "Rainbow";
				
				MusicSource.Play();
			}
			else
			{
				nextFire = Time.time + fireRate;
				GameObject clone = Instantiate(iceCream, iceCreamSpawn.position, iceCreamSpawn.rotation);

				clone.GetComponentInChildren<SpriteRenderer>().sprite = chosenIceCream;
				clone.name = color;

				myGamemode.iceCreamTimer--;
				MusicSource.Play();
			}
		} // Shooting Code

		if (Input.GetKey(KeyCode.UpArrow)) // Color Picker Code
		{

			chosenIceCream = yellowIceCream;
			color = "Yellow";
		}

		else if (Input.GetKey(KeyCode.RightArrow))
		{

			chosenIceCream = redIceCream;
			color = "Red";
		}

		else if (Input.GetKey(KeyCode.LeftArrow))
		{

			chosenIceCream = blueIceCream;
			color = "Blue";
		} // Color Picker Code
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
