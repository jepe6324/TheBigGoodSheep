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

	public Transform iceCreamSpawn;

	public GameObject redIceCream;
	public GameObject yellowIceCream;
	public GameObject blueIceCream;
	public GameObject rainbowIceCream;

	public SpriteRenderer colorRotatorRenderer;
	public Sprite colorRotatorYellow;
	public Sprite colorRotatorRed;
	public Sprite colorRotatorBlue;

	private Animator myAnimator;
	private GameObject chosenIceCream;
	private string color;
	private int rotationInt = 1; // I use LoopInt() to determine what colour to set the icecream to
	private float nextFire;
	Rigidbody2D myRigidbody;
	Gamemode myGamemode;

	// Use this for initialization
	void Start() {
		chosenIceCream = yellowIceCream;
		color = "Yellow";
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponentInChildren<Animator>();
		myGamemode = GetComponent<Gamemode>();
		MusicSource.clip = MusicClip;

		myAnimator.SetInteger("ColourInt", 1);
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) // Shoting code
		{
			if (myGamemode.rainbowTimer > 0)
			{
				nextFire = Time.time + fireRate;
				GameObject clone = Instantiate(rainbowIceCream, iceCreamSpawn.position, iceCreamSpawn.rotation);
				clone.name = "Rainbow";

				MusicSource.Play();
			}
			else
			{
				nextFire = Time.time + fireRate;
				GameObject clone = Instantiate(chosenIceCream, iceCreamSpawn.position, iceCreamSpawn.rotation);
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

		//speedY++;

		myRigidbody.position = new Vector2(
			Mathf.Clamp(myRigidbody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(myRigidbody.position.y, boundary.yMin, boundary.yMax));
	}

	void RotateColor()
	{
		if (Input.GetAxis("Rotate") < 0)
		{
			rotationInt = LoopInt(rotationInt + 1, 1, 3);
		}
		else
		{
			rotationInt = LoopInt(rotationInt - 1, 1, 3);
		}
		
		switch (rotationInt)
		{
			case 1:
				color = "Yellow";
				chosenIceCream = yellowIceCream;
				colorRotatorRenderer.sprite = colorRotatorYellow;
				myAnimator.SetInteger("ColourInt", 1);
				break;
			case 2:
				color = "Red";
				chosenIceCream = redIceCream;
				colorRotatorRenderer.sprite = colorRotatorRed;
				myAnimator.SetInteger("ColourInt", 2);
				break;
			case 3:
				color = "Blue";
				chosenIceCream = blueIceCream;
				colorRotatorRenderer.sprite = colorRotatorBlue;
				myAnimator.SetInteger("ColourInt", 3);
				break;
			default:
				break;
		}
	}


	int LoopInt(int value, int min, int max)
	{
		if (value > max)
			return min;
		if (value < min)
			return max;
		return value;
	}
}
