using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemode : MonoBehaviour {

	public float iceCreamTimer;
	public float iceCubeValue;
    public float iceCreamTimerMax;

    private float fillAmount;
    public Image content;

    private float rainbowFillAmount;
    public Image rainbowBar;

    public float rainbowTimer;
	public float rainbowDuration;

	public float obstaclePenalty;

	public Text scoreText;

    public AudioClip MusicClipIce;
    public AudioSource MusicSourceIce;
    public AudioClip MusicClipObstacle;
    public AudioSource MusicSourceObstacle;
    public AudioClip MusicClipRainbow;
    public AudioSource MusicSourceRainbow;

	// Use this for initialization
	void Start () {
		ScoreVariables.score = 0;
		ScoreVariables.highScoreBroken = false;
        MusicSourceIce.clip = MusicClipIce;
        MusicSourceObstacle.clip = MusicClipObstacle;
        MusicSourceRainbow.clip = MusicClipRainbow;
    }
	
	// Update is called once per frame
	void Update () {

        HandleBar(content, fillAmount);
        HandleBar(rainbowBar, rainbowFillAmount);

		if (rainbowTimer > 0)
		{
			rainbowTimer-= Time.deltaTime;
		}
		
		iceCreamTimer = clampIceCreamTimer( iceCreamTimer - Time.deltaTime);  // Remove one second from the icecream timer
		if (iceCreamTimer <= 0)
		{
			SceneManager.LoadScene("GameOver"); // If the icecream timer reaches 0 we lose
		}

		fillAmount = Map(iceCreamTimer, 0, iceCreamTimerMax, 0, 1);
        rainbowFillAmount = Map(rainbowTimer, 0, rainbowDuration, 0, 1);

		scoreText.text = "" + ScoreVariables.score;

		if (ScoreVariables.score > ScoreVariables.highScore)
		{
			ScoreVariables.highScore = ScoreVariables.score;
			ScoreVariables.highScoreBroken = true;
		}
	}

    private void HandleBar(Image content,float fillAmount)
    {
        content.fillAmount = fillAmount;
   
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "IceCube") // Checks the other objects tag to see if it is a "IceCube"
		{ // If it is do the things that it should do when getting into contact with an IceCube
			Destroy(other.gameObject);
            MusicSourceIce.Play();
            iceCreamTimer = clampIceCreamTimer(iceCreamTimer + iceCubeValue);
		}
		else if (other.tag == "Rainbow")
		{
			Destroy(other.gameObject);
			rainbowTimer += rainbowDuration;
            MusicSourceRainbow.Play();
		}
		else if (other.tag == "Obstacle")
		{
			Destroy(other.gameObject);
			iceCreamTimer -= obstaclePenalty;
            MusicSourceObstacle.Play();
        }
	}

	void SheepSatisfied() // This should be called when a sheep is fed with the right color
	{
		//Debug.Log("Satisfied!");
		ScoreVariables.score += 100;
		if (ScoreVariables.score > ScoreVariables.sessionRecord)
			ScoreVariables.sessionRecord = ScoreVariables.score;
		GetComponent<gameSpeedUp>().BroadcastMessage("IncrementHiddenScore");
	}

	void SheepUnsatisfied() // This should be called when a sheep is fed with the wrong color, or when they have not been fed at all.
	{
		//Debug.Log("Unsatisfied");
		ScoreVariables.score -= 50;
	}

	float clampIceCreamTimer(float value)
	{
		if (value > iceCreamTimerMax)
			return iceCreamTimerMax;
		else if (value < 0)
			return 0;
		else
			return value;
	}
}