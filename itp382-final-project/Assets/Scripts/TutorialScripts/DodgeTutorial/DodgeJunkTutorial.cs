using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeJunkTutorial : Tutorial {

	// Use this for initialization
	private bool isCurrentTutorial = false;
	public static bool beginToDropJunk;
	public static bool beginCountdownTimer;

	void Awake () {
	}
	
	public override void CheckIfHappening(){
		isCurrentTutorial = true;
		pauseTutorial.activateMenu = true;
	}

	void Update(){
		if (!isCurrentTutorial) {
			return;
		}

		beginToDropJunk = true;
		beginCountdownTimer = true;
		isCurrentTutorial = false;
	}
}

