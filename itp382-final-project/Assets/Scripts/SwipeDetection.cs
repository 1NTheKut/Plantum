using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour {

	public float swipeThreshold;

	private Vector2 startPos;

	Move2DPlayer character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.touchCount > 0) {
//			Touch touch = Input.touches [0];
//
//			switch (touch.phase) {
//			case TouchPhase.Began:
//				startPos = touch.position;
//				break;
//			
//			case TouchPhase.Ended:
//				float swipteDist = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
//				if (swipteDist == swipeThreshold) {
//					float swipeValue = Mathf.Sign (touch.position.x - startPos.x);
//					if (swipeValue > 0) {				
//						character.ChangeDirection ();
//						Debug.Log ("Right");
//					} else if (swipeValue < 0) {
//						character.ChangeDirection ();
//						Debug.Log ("Left");
//					}
//				
//				}
//				break;
//			}
//		}
	}
}
