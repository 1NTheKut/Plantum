using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JunkGenerator : MonoBehaviour {


	public float secondsBetweenJunkDrop = 4f;
	Vector3 dropPos;
	Vector3 scale = Vector3.one;
	float timeLeft;

	[SerializeField]
	private GameObject junkPreFab;
	public Sprite[] garbageSprites;
	int spriteRandomizer;
	public Image timer;

	[SerializeField]
	private float minJunkSize = 0.2f;
	private float maxJunkSize = 0.8f;

	// Use this for initialization
	void Start () {
		//Wait 2 seconds before dropping first one
		Invoke("createSpaceJunk", 3f);
	}

	void Update(){
		TimerAnimation countdown = timer.GetComponent<TimerAnimation> ();
		timeLeft = countdown.time;
		secondsBetweenJunkDrop = timeLeft/120 + .8f;
	}


	void createSpaceJunk(){
		dropPos.x = Random.Range (-8, 8);
		dropPos.y = 9;
		GameObject newJunk = Instantiate<GameObject> (junkPreFab);
		spriteRandomizer = Random.Range (0,5);
		if (spriteRandomizer < garbageSprites.Length && spriteRandomizer >= 0) {
			newJunk.GetComponent<SpriteRenderer>().sprite = garbageSprites[spriteRandomizer];
		}

		float randSize = Random.Range (minJunkSize, maxJunkSize);
		scale = new Vector3(randSize, randSize, 0);

		newJunk.transform.localScale = scale;
		newJunk.transform.position = dropPos;

		Invoke ("createSpaceJunk", secondsBetweenJunkDrop);
	}
}
