using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerAnimation : MonoBehaviour {

	Image fillImg;
	public static float timeAmount = 65f;
	public static float time;
	public static float timeTotal;
	public Text timeText;


	// Use this for initialization
	void Start () {
		fillImg = this.GetComponent<Image>();
		time = timeAmount;
		timeTotal = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeTotal += Time.deltaTime;
		if (time > 0) {
			time -= Time.deltaTime;
			fillImg.fillAmount = time / timeAmount;
			timeText.text = time.ToString ("F");
		} else {
			SceneManager.LoadScene("LoadNextLevel");
		}
	}
}
