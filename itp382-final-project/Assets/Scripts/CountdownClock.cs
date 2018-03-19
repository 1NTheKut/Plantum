using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownClock : MonoBehaviour
{

	public float timeLeft = 60.0f;

	public Text timerText;

	// Use this for initialization
	void Start ()
	{
		//find timer text
		GameObject timerGO = GameObject.Find ("Countdown");
		timerText = timerGO.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeLeft -= Time.deltaTime;
		timerText.text = "Time Left: " + timeLeft.ToString ();

		if (timeLeft <= 0) {
			Application.LoadLevel("WinScene");
		}

	}
}
