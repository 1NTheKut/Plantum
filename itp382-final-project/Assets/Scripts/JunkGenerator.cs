using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JunkGenerator : MonoBehaviour {


	float secondsBetweenJunkDrop = 4f;
	Vector3 dropPos;
	Vector3 scale = Vector3.one;

	[SerializeField]
	private GameObject junkPreFab;
	public Sprite[] garbageSprites;
	int spriteRandomizer;

	[SerializeField]
	private float minJunkSize = 0.2f;
	private float maxJunkSize = 0.8f;
	float addGravity = .1f;

	// Use this for initialization
	void Start () {
		//Wait 2 seconds before dropping first one
		Invoke("createSpaceJunk", 3f);
	}

	void Update(){
		secondsBetweenJunkDrop = 1 / ScoreManager.timer * 15f + .3f;
	}


	void createSpaceJunk(){
		dropPos.x = Random.Range (-8, 8);
		dropPos.y = 9;
		GameObject newJunk = Instantiate<GameObject> (junkPreFab);
		spriteRandomizer = Random.Range (0,5);
		if (spriteRandomizer < garbageSprites.Length && spriteRandomizer >= 0) {
			newJunk.GetComponent<SpriteRenderer>().sprite = garbageSprites[spriteRandomizer];
		}
		if (ScoreManager.timer > 10f) {
			newJunk.GetComponent<Rigidbody2D> ().AddForce (Vector3.down * addGravity);
		}

		float randSize = Random.Range (minJunkSize, maxJunkSize);
		scale = new Vector3(randSize, randSize, 0);
		newJunk.transform.localScale = scale;
		newJunk.transform.position = dropPos;

		Invoke ("createSpaceJunk", secondsBetweenJunkDrop);
		Invoke ("increaseGravity", 10f);
	}

	void increaseGravity() {
		addGravity += .1f;
	}
}
