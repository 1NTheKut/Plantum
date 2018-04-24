﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanetHealthManager : MonoBehaviour {

	public static List<GameObject> treePreFab = new List<GameObject>();

	GameObject planetGO;
	float timeLeft = 10f;

	// Use this for initialization
	void Start () {
		timeLeft = 10f;
		planetGO = GameObject.Find("planet_ground");
	}
	
	// Update is called once per frame
	void Update () {
		//checkPlanetHealth ();
		if (treePreFab.Count > 0) {
			//treesExist = true;
			if (ScoreManager.timer > 40f) {
				timeLeft = 5f;
			}
			else if (ScoreManager.timer > 20f) {
				timeLeft = 7f;
			}
			else {
				timeLeft = 10f;
			}
			planetGO.GetComponent<Animator> ().SetBool ("IsDying", false);
			//anim.SetBool("IsDying", false);
		} else {
			//anim.SetBool ("IsDying", true);
			timeLeft -= Time.deltaTime;
			planetGO.GetComponent<Animator> ().SetBool ("IsDying", true);
			//anim.SetBool ("IsDying", true);
			if (timeLeft <= 0) {
				SceneManager.LoadScene ("LoseScene_planetDied");
			}

		}
	}
		
}
