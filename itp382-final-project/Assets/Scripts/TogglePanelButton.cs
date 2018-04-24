using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TogglePanelButton : MonoBehaviour {

	PauseScript pauseScript;

	void Start () {
		pauseScript = this.GetComponent<PauseScript> ();
	}

	public void TogglePanel(GameObject panel) {
		panel.SetActive (!panel.activeSelf);
		pauseScript.Pause ();
	}
}
