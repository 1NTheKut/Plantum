using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialCountdownTimer : MonoBehaviour
{
	
	Image fillImg;
	public float timeAmount = 10f;
	public float time;
	public Text timeText;

	// Use this for initialization
	void Start ()
	{
		fillImg = this.GetComponent<Image>();
		time = timeAmount;
	}

	// Update is called once per frame
	void Update ()
	{
		if (DodgeJunkTutorial.beginCountdownTimer == true) {
			if (time > 0) {
				time -= Time.deltaTime;
				fillImg.fillAmount = time / timeAmount;
				timeText.text = time.ToString ("F");
			}
			else if (time <= 0) {
				TutorialManager.Instance.CompletedAllTutorials();
			}
		}

	}

}