using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialCountdownTimer : MonoBehaviour
{
	public float timeLeft = 30f;
	public Text timerText;

	// Use this for initialization
	void Start ()
	{
		GameObject timerGO = GameObject.Find ("Countdown");
		timerText = timerGO.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (DodgeJunkTutorial.beginCountdownTimer == true) {
			timeLeft -= Time.deltaTime;
			timerText.text = "Time Left: " + timeLeft.ToString ("f2");
			if (timeLeft <= 0) {
				TutorialManager.Instance.CompletedAllTutorials();
			}
		}

	}

}