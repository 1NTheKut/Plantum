using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JunkGenTutorial : MonoBehaviour {

	public float secondsBetweenJunkDrop = 4f;
	Vector3 dropPos;
	Vector3 scale = Vector3.one;
	float timeLeft;

	[SerializeField]
	private GameObject junkPreFab;
	public Sprite[] garbageSprites;
	int spriteRandomizer;

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private float minJunkSize = 0.4f;
	private float maxJunkSize = 0.75f;

	public Image timer;

	// Use this for initialization
	void Start () {
		//Wait 2 seconds before dropping first one
//		if (DodgeJunkTutorial.beginToDropJunk == true) {
//			Invoke ("createSpaceJunk", 0.0f);
//		}
	}

	void Update(){
		if (DodgeJunkTutorial.beginToDropJunk == true) {
			Invoke ("createSpaceJunk", 3.0f);
		}

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
