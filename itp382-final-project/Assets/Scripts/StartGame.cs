using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void LoadLevel() {
		//TO DO: Make an switch statement to load scene
		SceneManager.LoadScene("Level1");
	}
}