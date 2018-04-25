using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlantTutorial : Tutorial {

	public List<Button> plantButtons = new List<Button> ();
	private bool isCurrentTutorial = false;

//	public Button first;
//	public Button second;
//	public Button third;
//	bool firstButton;
//	bool secondButton;
//	bool thirdButton;

	public override void CheckIfHappening(){
		isCurrentTutorial = true;
		pauseTutorial.activateMenu = true;
	}
	// Use this for initialization
	void Start () {
//		firstButton = true;
//		secondButton = true;
//		thirdButton = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isCurrentTutorial) {
			return;
		}

		for (int i = 0; i < plantButtons.Count; i++) {
			if (Input.GetMouseButtonDown (i)) {
				plantButtons.RemoveAt (i);
			}

//			plantButtons [i].onClick.AddListener (() => RemoveButton (i));
//			plantButtons [i].onClick.AddListener (() => RemoveButton (i));
//			plantButtons [i].onClick.AddListener (() => RemoveButton (i));
		}

//		second.GetComponent<Button>().onClick.AddListener(() => RemoveButton(1));
//		third.GetComponent<Button>().onClick.AddListener(() => RemoveButton(2));

//		for (int i = 0; i <= plantButtons.Count; i++) {
//			
//			if (first) {
//				plantButtons.RemoveAt (i);
//			}
//			if (Input.GetMouseButtonDown (i)) {
//				plantButtons.RemoveAt (i);
//				break;
//				if (plantButtons [i].name == "PlantButton_01" && firstButton == true) {
//						plantButtons.RemoveAt (i);
//						firstButton = false;
//					break;
//				}
//				else if (plantButtons [i].name == "PlantButton_02" && secondButton == true) {
//						plantButtons.RemoveAt (i);
//						secondButton = false;
//					break;
//				}
//				else if (plantButtons [i].name == "PlantButton_03" && thirdButton == true) {
//						plantButtons.RemoveAt (i);
//						thirdButton = false;
//					break;
//				}
//			}
//		}

		if (plantButtons.Count == 1) {
			pauseTutorial.activateMenu = false;
		}  else if (plantButtons.Count == 0) {
			isCurrentTutorial = false;
			TutorialManager.Instance.CompletedCurrentTutorial ();
		}
	}

//	void RemoveButton(int index){
//		plantButtons.RemoveAt(index);
//	}
}
