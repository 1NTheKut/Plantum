using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	public int order;

	[TextArea(3,10)]
	public string explanation;

	// Use this for initialization
	void Awake() {
		TutorialManager.Instance.tutorials.Add (this);
		
	}

	public virtual void CheckIfHappening() { }


}
