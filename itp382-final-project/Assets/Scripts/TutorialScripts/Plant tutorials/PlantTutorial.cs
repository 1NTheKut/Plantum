using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlantTutorial : Tutorial {

	public List<Button> plantButtons = new List<Button> ();
	private bool isCurrentTutorial = false;

	public override void CheckIfHappening(){
		isCurrentTutorial = true;
		for (int i = 0; i < plantButtons.Count; i++) {
			if (Input.GetMouseButtonDown(i)) {
				plantButtons.RemoveAt(i);
				break;
			}
		}

		if (plantButtons.Count == 0) {
			TutorialManager.Instance.CompletedCurrentTutorial ();		
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
