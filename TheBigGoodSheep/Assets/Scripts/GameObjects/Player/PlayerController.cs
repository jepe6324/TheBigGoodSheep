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

	public SpriteRenderer colorRotatorRenderer;
	public Sprite colorRotatorYellow;
	public Sprite colorRotatorRed;
	public Sprite colorRotatorBlue;

	public Sprite playerSpriteYellow;
	public Sprite playerSpriteRed;
	public Sprite playerSpriteBlue;

	private SpriteRenderer mySpriteRenderer;
	private Sprite chosenIceCream;
	private string color;
	private int rotationInt = 1; // I use modulo to determine what colour to set the icecream to
	private float nextFire;
	Rigidbody2D myRigidbody;
	Gamemode myGamemode;

	// Use this for initialization
	void Start() {
		chosenIceCream = yellowIceCream;
		color = "Yellow";
		myRigidbody = GetComponent<Rigidbody2D>();
		mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		myGamemode = GetComponent<Gamemode>();
		MusicSource.clip = MusicClip;

		mySpriteRenderer.sprite = playerSpriteYellow;
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


		if (Input.GetButtonDown("Rotate"))
		{
			RotateColor();
		}
	}

	void FixedUpdate() {
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

	void RotateColor()
	{
		if (Input.GetAxis("Rotate") < 0)
		{
			rotationInt = loopInt(rotationInt + 1, 1, 3);
		}
		else
		{
			rotationInt = loopInt(rotationInt - 1, 1, 3);
		}
		
		switch (rotationInt)
		{
			case 1:
				color = "Yellow";
				chosenIceCream = yellowIceCream;
				colorRotatorRenderer.sprite = colorRotatorYellow;
				mySpriteRenderer.sprite = playerSpriteYellow;
				break;
			case 2:
				color = "Red";
				chosenIceCream = redIceCream;
				colorRotatorRenderer.sprite = colorRotatorRed;
				mySpriteRenderer.sprite = playerSpriteRed;
				break;
			case 3:
				color = "Blue";
				chosenIceCream = blueIceCream;
				colorRotatorRenderer.sprite = colorRotatorBlue;
				mySpriteRenderer.sprite = playerSpriteBlue;
				break;
			default:
				break;
		}
	}


	int loopInt(int value, int min, int max)
	{
		if (value > max)
			return min;
		if (value < min)
			return max;
		return value;
	}
}
