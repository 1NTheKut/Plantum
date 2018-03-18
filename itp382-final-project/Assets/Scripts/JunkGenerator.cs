using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkGenerator : MonoBehaviour {

//	public GameObject spaceJunkPrefab;
	public float secondsBetweenJunkDrop = 4f;
	Vector3 dropPos;
//	Vector3 screenPos;
	[SerializeField]
	private GameObject spaceJunk;

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private float minJunkSize = 0.5f;
	private float maxJunkSize = 0.5f;

	// Use this for initialization
	void Start () {
		//Drop space junk every 2 seconds
		Invoke("createSpaceJunk", 2f);
	}

	void Update(){

//		if (Input.GetMouseButtonDown (0)) {
//			createSpaceJunk ();
//		}
		//Invoke("createpaceJunk", 2f);
	}


	void createSpaceJunk(){
		//dropPos.x = Random.Range (-12, 12);
		//dropPos.y = Random.Range (-12, 12);
		//dropPos.y = Random.Range (-12, 12);
		GameObject junk = Instantiate (spaceJunk, new Vector3 (cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint (Input.mousePosition).y, 0), Quaternion.identity) as GameObject;

		float randSize = Random.Range (minJunkSize, maxJunkSize);

		junk.transform.localScale = new Vector3 (randSize, randSize, 0);

		Invoke ("createSpaceJunk", secondsBetweenJunkDrop);
	
	}
}

	// Update is called once per frame
//	void Update () {
//		screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
//	}
//
//	void DropJunk() {
//		GameObject spaceJunk_top = Instantiate<GameObject> (spaceJunkPrefab);
//		dropPos.x = Random.Range(-12,12);
//		dropPos.y = 15;
//		spaceJunk_top.transform.position = dropPos;
//
//		GameObject spaceJunk_bottom = Instantiate<GameObject> (spaceJunkPrefab);
//		dropPos.x = Random.Range(-12,12);
//		dropPos.y = -15;
//		spaceJunk_bottom.transform.position = dropPos;
//
//		GameObject spaceJunk_left = Instantiate<GameObject> (spaceJunkPrefab);
//		dropPos.y = Random.Range(-12,12);
//		dropPos.x = -15;
//		spaceJunk_left.transform.position = dropPos;
//
//		GameObject spaceJunk_right = Instantiate<GameObject> (spaceJunkPrefab);
//		dropPos.y = Random.Range(-12,12);
//		dropPos.x = 15;
//		spaceJunk_right.transform.position = dropPos;
//
//		Invoke ("DropJunk", secondsBetweenJunkDrop);
//	}
//}
