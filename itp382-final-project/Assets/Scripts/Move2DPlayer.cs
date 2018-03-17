using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2DPlayer : MonoBehaviour {

	//speed that the player will go
	public float moveSpeed = 300;
	public GameObject character;

	private Rigidbody2D playerCharacter;
	private float screenWidth;

	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
		playerCharacter = character.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		int numTouches = 0;

		while (numTouches < 0) {
			if (Input.GetTouch (numTouches).position.x > (screenWidth / 2)) {
				movePlayer (1.0f);
			} if (Input.GetTouch (numTouches).position.x < (screenWidth / 2)){
				movePlayer(-1.0F);
			}
			++numTouches;
		}
	}

	void FixedUpdate(){
		#if UNITY_EDITOR
		movePlayer(Input.GetAxis("Horizontal"));
		#endif 
	}
	private void movePlayer(float moveSideToSide){
		playerCharacter.AddForce (new Vector2 (moveSideToSide * moveSpeed * Time.deltaTime, 0));

	
	}
}
