using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

	public List<Tutorial> tutorials = new List<Tutorial>();
	public Button exitButton;
	 
	public Text tutorialText;

	private static TutorialManager tutorialInstance;
	public static TutorialManager Instance{
		get{
			if (tutorialInstance == null) {
				tutorialInstance = GameObject.FindObjectOfType<TutorialManager> ();
			}
			if (tutorialInstance == null) {
				Debug.Log ("No TutorialManager Found");
			}

			return tutorialInstance;
		}
	
	}

	private Tutorial currentTutorial;
	// Use this for initialization
	void Start () {
		SetNextTutorial (0);
		exitButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTutorial) {
			currentTutorial.CheckIfHappening ();
		}
	}

	public void CompletedCurrentTutorial(){
		SetNextTutorial (currentTutorial.order + 1);
	}

	public void SetNextTutorial(int currentOrder){
		currentTutorial = GetTutorialByOrder (currentOrder);
		if (!currentTutorial) {
			//CompletedAllTutorials ();
			return;
		}

		tutorialText.text = currentTutorial.explanation;
	}

	public void CompletedAllTutorials(){
		exitButton.interactable = true;
		tutorialText.text = "All tutorials completed!";

	}

	public Tutorial GetTutorialByOrder(int order){
		for (int i = 0; i < tutorials.Count; i++){
			if ( tutorials[i].order == order){
				return tutorials[i];
			}
		}
		return null; 
	}
}
