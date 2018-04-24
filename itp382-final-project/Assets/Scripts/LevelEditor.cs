using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelEditor : MonoBehaviour {

	int currLevel = -1;
	public List<GameObject> Levels;
	public List<GameObject> Prefabs;
	Animator window;
	[HideInInspector]
	public GameObject level;
	// Use this for initialization
	void Start () {
		SceneManager.LoadScene ("Level");
		//NextLevel ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void NextLevel(){
		if (currLevel < Levels.Count - 1) {
			currLevel++;
		}

		if (level) {
			level.SetActive (false);
			Destroy (level);
		}

		level = Instantiate (Levels [currLevel]);
		SceneManager.LoadScene ("Level");
		//ReplaceObjects ();
		//level.SetActive (false);
	}
		
}
