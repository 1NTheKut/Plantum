using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[Header("Set Dynamically")]
	public Text scoreText;
	public Text highScoreText;
	public float score;
	public static int highScore;
	public static float timer;

	void Awake() {
		//starting score
		if (PlayerPrefs.HasKey ("HighScore") && PlayerPrefs.GetInt ("HighScore") > highScore) {
			highScore = PlayerPrefs.GetInt ("HighScore");
		}
		PlayerPrefs.SetInt ("HighScore", highScore);
	}

	// Use this for initialization
	void Start () {
		timer = 0f;
		highScoreText.text = "High Score: " + highScore;
		scoreText.text = "Score: 0";
	}

	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		score += Time.deltaTime * 10;
		scoreText.text = "Score: " + Mathf.Round(score).ToString ();

		//update high score
		if (score > highScore) {
			highScore = (int)score;
			highScoreText.text = "High Score: " + highScore.ToString();
		}

		//update player prefs high score
		if (score > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", (int)score);
		}
	}

	public void AddPlantScore( int plantIndex) {
		switch (plantIndex) {
		case 0:
			score += 100;
			break;
		case 1:
			score += 200;
			break;
		case 2:
			score += 300;
			break;
		}

	}
}
