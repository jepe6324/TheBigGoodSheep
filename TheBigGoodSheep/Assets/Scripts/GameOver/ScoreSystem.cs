using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {
	public Text score;
	public Text highScore;
	
	// Use this for initialization
	void Start () {
		score.text = "Score: " + ScoreVariables.score;
		
		if (ScoreVariables.highScoreBroken == true)
		{
			// Highscore broken code
			PlayerPrefs.SetInt("highScore", ScoreVariables.highScore);
		}

		highScore.text = "" + PlayerPrefs.GetInt("highScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void resetHighScore() // Use this to reset the high score. Should not be available to Jerry.
	{
		ScoreVariables.highScore = 0;
		PlayerPrefs.SetInt("highScore", 0);
	}
}


public class ScoreVariables
{
	static public int score = 0;
	static public int highScore = PlayerPrefs.GetInt("highScore");    // this is reachable from everywhere
	static public bool highScoreBroken = false;
}
