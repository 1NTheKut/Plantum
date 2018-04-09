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

	GameObject player;
	public Rigidbody2D character;

	// Use this for initialization
	void Start () {
		//edits for making buttons to change direction
		player = GameObject.Find("Player");
		character = player.GetComponent<Rigidbody2D>();

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
		player.GetComponent<Animator> ().SetBool ("isWalking", true);
		player.GetComponent<Animator> ().SetBool ("isPlanting", false);
		moveCharacter (-1.0f);
	}

	void MoveRight(){
		player.GetComponent<Animator> ().SetBool ("isWalking", true);
		player.GetComponent<Animator> ().SetBool ("isPlanting", false);
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
//			Vector3 pos = transform.position;
//			pos.x += moveSpeed * Time.deltaTime;
//			transform.position = pos;

			//change direction if borders hit
			if (character.position.x < leftBorder) {
				moveCharacter (1.0f);
				//Debug.Log ("HIT LEFT");
			} else if (character.position.x > rightBorder) {
				moveCharacter (-1.0f);
				//Debug.Log ("HIT RIGHT");
			}
		}
	}

	public void moveCharacter(float input){
		//player.GetComponent<Animator> ().SetBool ("isWalking", true);
		character.velocity = new Vector2 (input * 100.0f * Time.deltaTime, 0);
	}

	public void ChangeDirection(float input) {
		//moveSpeed = moveSpeed * input;
		character.AddForce(new Vector2 (input * 100.0f * Time.deltaTime, 0));
	}

	public IEnumerator PlayerIsPlanting() {
		isPlanting = true;

		//Debug.Log ("isPlanting TRUE");
		//moveSpeed = 0f;
		character.AddForce(new Vector2 (0 * Time.deltaTime, 0));
		yield return new WaitForSeconds (3.0f);
		//character.velocity = new Vector2 (1 * 100.0f * Time.deltaTime, 0);
		//moveSpeed = 5f;
	}

	public void PlayerDonePlanting() {
		isPlanting = false;
		character.velocity = new Vector2 (0* Time.deltaTime, 0);
//		player.GetComponent<Animator> ().SetBool ("isWalking", true);
//		player.GetComponent<Animator> ().SetBool ("isPlanting", false);
	}
		
}
