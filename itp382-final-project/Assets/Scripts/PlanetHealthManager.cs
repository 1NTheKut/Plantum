using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanetHealthManager : MonoBehaviour {

	public static List<GameObject> treePreFab = new List<GameObject>();

	GameObject planetGO;
	float timeLeft = 5f;
	public Text timerText;

	// Use this for initialization
	void Start () {

		planetGO = GameObject.Find("planet_ground");
		GameObject timerGO = GameObject.Find ("PlanetHealth");
		timerText = timerGO.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//checkPlanetHealth ();
		if (treePreFab.Count > 0) {
			//treesExist = true;
			timeLeft = 5f;
			timerText.text = "Planet Dies In";
			planetGO.GetComponent<Animator> ().SetBool ("IsDying", false);
			//anim.SetBool("IsDying", false);
		} else {
			//anim.SetBool ("IsDying", true);
			timeLeft -= Time.deltaTime;
			timerText.text = "Planet Dies In " + timeLeft.ToString("f2");
			planetGO.GetComponent<Animator> ().SetBool ("IsDying", true);
			//anim.SetBool ("IsDying", true);
			if (timeLeft <= 0) {
				SceneManager.LoadScene ("LoseScene");
			}

		}
	}
		
}
