using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOptions : MonoBehaviour {

	public void GoHome() {
		SceneManager.LoadScene ("LaunchScene");
	}

	public void GoTutorial() {
		SceneManager.LoadScene ("Tutorial_Scene");
	}
}
