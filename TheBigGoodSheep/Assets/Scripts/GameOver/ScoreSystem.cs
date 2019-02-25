using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {
	public Text score;
	public Text HighScore;
	
	// Use this for initialization
	void Start () {
		score.text = "Score: " + ApplicationModel.score;
		//HighScore.text = "HighScore: " + HighScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
