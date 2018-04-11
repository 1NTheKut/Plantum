using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine;

//make each level on the same scene and have everything data
//driven so you only change the data of each scene

//show represenation for the different plants and how they differ
public class LoadLevel3 : MonoBehaviour {

	public Button nextLevelButton;

	// Use this for initialization
	void Start () {
		Button loadButton = nextLevelButton.GetComponent<Button> ();
		loadButton.onClick.AddListener (LoadLevel);
	}

	public void LoadLevel(){
		SceneManager.LoadScene ("Level3");
	}

	// Update is called once per frame
	void Update () {

	}
}
