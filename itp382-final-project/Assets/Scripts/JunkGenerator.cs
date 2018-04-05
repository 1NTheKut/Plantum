using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkGenerator : MonoBehaviour {

	public float secondsBetweenJunkDrop = 2f;
	Vector3 dropPos;
	Vector3 scale = Vector3.one;
	float timeLeft;

	[SerializeField]
	private GameObject junkPreFab;
	public Sprite[] sprites; //TO DO: use this instead of prefab? maybe create an array of prefabs instead

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private float minJunkSize = 0.1f;
	private float maxJunkSize = 0.35f;

	// Use this for initialization
	void Start () {
		//Wait 2 seconds before dropping first one
		Invoke("createSpaceJunk", 2f);
	}

	void Update(){
		CountdownClock countdown = Camera.main.GetComponent<CountdownClock> ();
		timeLeft = countdown.timeLeft;
		secondsBetweenJunkDrop = timeLeft/60 + .2f;
	}


	void createSpaceJunk(){
		dropPos.x = Random.Range (-8, 8);
		dropPos.y = 9;
		GameObject newJunk = Instantiate<GameObject> (junkPreFab);

		float randSize = Random.Range (minJunkSize, maxJunkSize);
		scale = new Vector3(randSize, randSize, 0);

		newJunk.transform.localScale = scale;
		newJunk.transform.position = dropPos;

		Invoke ("createSpaceJunk", secondsBetweenJunkDrop);
	}
}
