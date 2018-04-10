using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void LoadLevel() {
		SceneManager.LoadScene("LaunchScene");
	}
}