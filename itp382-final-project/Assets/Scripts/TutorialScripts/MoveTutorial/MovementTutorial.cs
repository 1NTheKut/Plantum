using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementTutorial : Tutorial {

	public List<Button> Buttons = new List<Button>();

	void Start(){
	}

	public override void CheckIfHappening(){
		pauseTutorial.activateMenu = true;
		for (int i = 0; i <= Buttons.Count; i++) {
			if (Input.GetMouseButtonDown(i)) {
				Buttons.RemoveAt(i);
				break;
			}
		}

		if (Buttons.Count == 1) {
			pauseTutorial.activateMenu = false;
		} else if (Buttons.Count == 0) {
			TutorialManager.Instance.CompletedCurrentTutorial ();
		}

	}
}
