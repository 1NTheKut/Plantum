using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementTutorial : Tutorial {

	public List<Button> Buttons = new List<Button>();

	public Button goOn;

	void Start(){
		goOn.interactable = false;
	}

	public override void CheckIfHappening(){
		for (int i = 0; i < Buttons.Count; i++) {
			if (Input.GetMouseButtonDown(i)) {
				Buttons.RemoveAt(i);
				break;
			}
		}

		if (Buttons.Count == 0) {
			TutorialManager.Instance.CompletedCurrentTutorial ();
			goOn.interactable = true;
		}
	}
}
