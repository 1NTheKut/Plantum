using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public GameObject treePreFab;
	GameObject world;
	GameObject player;
	bool isFreePos;

	// Use this for initialization
	void Start () {
		bool supportsMultiTouch = Input.multiTouchEnabled;
		if (!supportsMultiTouch) {
			print ("Multitouch not supported");
		}
		isFreePos = true;
		world = GameObject.Find ("Planet");
		player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {
		int nbTouches = Input.touchCount;


		if (nbTouches > 0) {
			for (int i = 0; i < nbTouches; i++) {
				Touch touch = Input.GetTouch (i);

				if (touch.phase == TouchPhase.Began) {
					PlantTree ();
				} 

			}
		} else if (Input.GetMouseButtonDown (0)) {
			PlantTree ();


		}
		isFreePos = true;
	}

	void PlantTree() {
		foreach(GameObject plantedTree in GameObject.FindGameObjectsWithTag("tree"))
		{
			//Debug.Log ("PlayerPos = " + player.transform.position.x + ", treePos = " + plantedTree.transform.position.x);
			if(Mathf.Round(player.transform.position.x) == Mathf.Round(plantedTree.transform.position.x))
			{
				//Debug.Log ("Found tree");
				isFreePos = false;
			}
		}
		if (isFreePos) {
			//If no tree there already, create another tree
			Vector3 spawnPos = player.transform.position;
			Quaternion spawnRotation = Quaternion.identity;
			spawnPos.z += 1;
			spawnPos.y -= .5f;
			GameObject newCharacter = Instantiate(treePreFab, spawnPos, spawnRotation) as GameObject;
			newCharacter.transform.LookAt(world.transform);
			newCharacter.transform.Rotate(-90, 0, 0);
		}
	}
}