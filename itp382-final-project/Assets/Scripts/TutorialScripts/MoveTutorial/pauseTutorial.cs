using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseTutorial : MonoBehaviour {

	[SerializeField] public GameObject panel;
	public static bool activateMenu = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (activateMenu == true) {
			panel.SetActive (true);
		} else if (activateMenu == false) {
			panel.SetActive (false);
		}
	}
}
