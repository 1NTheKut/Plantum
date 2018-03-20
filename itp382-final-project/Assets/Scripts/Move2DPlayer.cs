using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2DPlayer : MonoBehaviour {

	float dist;
	float leftBorder;
	float rightBorder;
	public float moveSpeed = 2f;
	public GameObject character;
	public float leftAndRightEdge = 10f;
	public bool isPlanting = false;

	// Use this for initialization
	void Start () {
//		screenWidth = Screen.width;
//		playerCharacter = character.GetComponent<Rigidbody2D> ();
		dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
	}
	
	// Update is called once per frame
	void Update () {

		if (!isPlanting) {
			Vector3 pos = transform.position;
			pos.x += moveSpeed * Time.deltaTime;
			transform.position = pos;

			//change direction if borders hit
			if (pos.x < leftBorder) {
				ChangeDirection ();
			} else if (pos.x > rightBorder) {
				ChangeDirection ();
			}
		}
	}

	public void ChangeDirection() {
		moveSpeed = moveSpeed * (-1);
	}

	public void PlayerIsPlanting() {
		isPlanting = true;
	}

	public void PlayerDonePlanting() {
		isPlanting = false;
	}
		
}
