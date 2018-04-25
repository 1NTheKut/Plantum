using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TogglePanelButton : MonoBehaviour {

	pauseScript pauseScript;

	void Start () {
		pauseScript = this.GetComponent<pauseScript> ();
	}

	public void TogglePanel(GameObject panel) {
		panel.SetActive (!panel.activeSelf);
		pauseScript.Pause ();
	}
}
