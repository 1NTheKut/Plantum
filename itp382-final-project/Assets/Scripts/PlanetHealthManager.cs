using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanetHealthManager : MonoBehaviour {

	public static List<GameObject> treePreFab = new List<GameObject>();

	//GameObject planetGO = GameObject.Find("planet_ground");

	//Animator anim = planetGO.GetComponent<Animator>();

	float timeLeft = 5f;
	public Text timerText;

	// Use this for initialization
	void Start () {
		
		GameObject timerGO = GameObject.Find ("PlanetHealth");
		timerText = timerGO.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//checkPlanetHealth ();
		if (treePreFab.Count > 0) {
			//treesExist = true;
			//anim.SetBool("IsDying", false);
			timeLeft = 5f;
			timerText.text = "Planet Dies In";
			Debug.Log (treePreFab.Count);
		} else {
			//anim.SetBool ("IsDying", true);
			timeLeft -= Time.deltaTime;
			timerText.text = "Planet Dies In " + timeLeft.ToString("f2");
			if (timeLeft <= 0) {
				SceneManager.LoadScene ("LoseScene");
			}
			Debug.Log (treePreFab.Count);
		}
	}
		
}
