using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpaceJunk : MonoBehaviour {

	public GameObject spaceJunkPrefab;
	public float secondsBetweenJunkDrop = 4f;
	Vector3 dropPos;
	Vector3 screenPos;

	// Use this for initialization
	void Start () {
		//Drop space junk every 2 seconds
		Invoke("DropJunk", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
	}

	void DropJunk() {
		GameObject spaceJunk_top = Instantiate<GameObject> (spaceJunkPrefab);
		dropPos.x = Random.Range(-12,12);
		dropPos.y = 15;
		spaceJunk_top.transform.position = dropPos;

		GameObject spaceJunk_bottom = Instantiate<GameObject> (spaceJunkPrefab);
		dropPos.x = Random.Range(-12,12);
		dropPos.y = -15;
		spaceJunk_bottom.transform.position = dropPos;

		GameObject spaceJunk_left = Instantiate<GameObject> (spaceJunkPrefab);
		dropPos.y = Random.Range(-12,12);
		dropPos.x = -15;
		spaceJunk_left.transform.position = dropPos;

		GameObject spaceJunk_right = Instantiate<GameObject> (spaceJunkPrefab);
		dropPos.y = Random.Range(-12,12);
		dropPos.x = 15;
		spaceJunk_right.transform.position = dropPos;

		Invoke ("DropJunk", secondsBetweenJunkDrop);
	}
}
