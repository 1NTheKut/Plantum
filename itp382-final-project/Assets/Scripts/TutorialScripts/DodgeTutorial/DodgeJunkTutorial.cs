using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeJunkTutorial : Tutorial {

	// Use this for initialization
	private bool isCurrentTutorial = false;
	public static bool beginToDropJunk;
	public static bool beginCountdownTimer;

	void Awake () {
		//beginCountdownTimer = false;
	}
	
	public override void CheckIfHappening(){
		beginToDropJunk = true;
		beginCountdownTimer = true;
	}
}

