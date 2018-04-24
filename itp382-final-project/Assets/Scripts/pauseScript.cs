using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour {

	public bool paused;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		paused = false;
		panel = GameObject.Find ("MenuPanel");
		panel.SetActive (false);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause() {
		paused = !paused;
		if (paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}
