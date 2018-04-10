using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Move2DPlayer : MonoBehaviour {

	float dist;
	float leftBorder;
	float rightBorder;
	float timer;
//	float moveSpeed = 100.0f;
	public Rigidbody2D character;
	public float leftAndRightEdge = 10f;
	public bool isPlanting = false;

	public Button left;
	public Button right;

	// Use this for initialization
	void Start () {
//		playerCharacter = character.GetComponent<Rigidbody2D> ();
		//edits for making buttons to change direction
		character = character.GetComponent<Rigidbody2D>();
		//end edits
		dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

//		Button btn = left.GetComponent<Button>();
//		Button rightbtn = right.GetComponent<Button> ();
//		btn.onClick.AddListener (MoveLeft);
//		rightbtn.onClick.AddListener (MoveRight);

	}

	void MoveLeft(){
		moveCharacter (-1.0f);
	}

	void MoveRight(){
		moveCharacter (1.0f);	
	}
	
	// Update is called once per frame
	void Update () {
		Button btn = left.GetComponent<Button>();
		Button rightbtn = right.GetComponent<Button> ();
		btn.onClick.AddListener (MoveLeft);
		rightbtn.onClick.AddListener (MoveRight);

		timer += Time.deltaTime;
		if (!isPlanting) {
			//change direction if borders hit
			if (character.position.x < leftBorder) {
				moveCharacter (1.0f);
			} else if (character.position.x > rightBorder) {
				moveCharacter (-1.0f);
			}
		}
	}

	public void moveCharacter(float input){
		character.velocity = new Vector2 (input * 100.0f * Time.deltaTime, 0);
	}

	public void ChangeDirection(float input) {
		//moveSpeed = moveSpeed * input;
		character.AddForce(new Vector2 (input * 100.0f * Time.deltaTime, 0));
	}

	public IEnumerator PlayerIsPlanting() {
		isPlanting = true;
		//moveSpeed = 0f;
		character.AddForce(new Vector2 (0 * Time.deltaTime, 0));
		yield return new WaitForSeconds (3.0f);
		//character.velocity = new Vector2 (1 * 100.0f * Time.deltaTime, 0);
		//moveSpeed = 5f;
	}

	public void PlayerDonePlanting() {
		isPlanting = false;
		character.velocity = new Vector2 (0* Time.deltaTime, 0);

	}
		
}
