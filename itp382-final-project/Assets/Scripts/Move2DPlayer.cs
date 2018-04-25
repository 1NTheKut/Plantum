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
//	public 
	public float leftAndRightEdge = 10f;
	public bool isPlanting = false;

	public Button left;
	public Button right;

	public float turnSpeed;
	float someScale;

	GameObject player;
	public Rigidbody2D character;

	private SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		//edits for making buttons to change direction
		player = GameObject.Find("Player");
		character = player.GetComponent<Rigidbody2D>();
		mySprite = GetComponent<SpriteRenderer> ();

		dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		//someScale = character.position.x;

	}

	void turnCharacter(){
		float targetAngle = -360.0f;
		transform.rotation = 
			Quaternion.Slerp( transform.rotation, 
				Quaternion.Euler( 0, 0, targetAngle ), 
				turnSpeed * Time.deltaTime );
	}

	void MoveLeft(){
		player.GetComponent<Animator> ().SetBool ("isWalking", true);
		player.GetComponent<Animator> ().SetBool ("isPlanting", false);
		moveCharacter (-1.0f);
		mySprite.flipX = true;
	}

	void MoveRight(){
		player.GetComponent<Animator> ().SetBool ("isWalking", true);
		player.GetComponent<Animator> ().SetBool ("isPlanting", false);
		moveCharacter (1.0f);
		mySprite.flipX = false;
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
				mySprite.flipX = false;
			} else if (character.position.x > rightBorder) {
				moveCharacter (-1.0f);
				mySprite.flipX = true;
			}
		}
	}

	public void moveCharacter(float input){
		//player.GetComponent<Animator> ().SetBool ("isWalking", true);
		character.velocity = new Vector2 (input * 100.0f * Time.deltaTime, 0);
		//character.position = new Vector2 (-1 * someScale, character.position.y);
	}

	public void ChangeDirection(float input) {
		//moveSpeed = moveSpeed * input;
		character.AddForce(new Vector2 (input * 100.0f * Time.deltaTime, 0));
	}

	public IEnumerator PlayerIsPlanting(float waitTime) {
		isPlanting = true;

		//Debug.Log ("isPlanting TRUE");
		//moveSpeed = 0f;
		character.AddForce(new Vector2 (0 * Time.deltaTime, 0));
		yield return new WaitForSeconds (waitTime);
		//character.velocity = new Vector2 (1 * 100.0f * Time.deltaTime, 0);
		//moveSpeed = 5f;
	}

	public void PlayerDonePlanting() {
		isPlanting = false;
		character.velocity = new Vector2 (0* Time.deltaTime, 0);
//		player.GetComponent<Animator> ().SetBool ("isWalking", false);
//		player.GetComponent<Animator> ().SetBool ("isPlanting", false);
	}
		
}
