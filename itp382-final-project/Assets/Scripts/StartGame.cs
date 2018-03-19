using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void LoadLevel() {
		SceneManager.LoadScene("phase1_2dDraft");
	}
}