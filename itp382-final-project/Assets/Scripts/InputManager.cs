using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public GameObject treePreFab;
	public GameObject world;
	Vector3 centerOfWorld;
	Vector3 pos;
	Vector3 normal;


	// Use this for initialization
	void Start () {
		bool supportsMultiTouch = Input.multiTouchEnabled;
		if (!supportsMultiTouch) {
			print ("Multitouch not supported");
		}
		centerOfWorld = world.transform.position;
	}

	// Update is called once per frame
	void Update () {
		int nbTouches = Input.touchCount;

		if (nbTouches > 0) {
			for (int i = 0; i < nbTouches; i++) {
				Touch touch = Input.GetTouch (i);

				if (touch.phase == TouchPhase.Began) {
					GameObject tree = Instantiate<GameObject> (treePreFab);
					tree.transform.position = touch.position;
					//tree.transform.position.y = world.transform.position.y + world.
				} 

			}
		} else if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Vector3 spawnPosition = Vector3.Normalize (hit.point) * ((world.transform.localScale.x / 2) + treePreFab.transform.localScale.y * 0.5f) + world.transform.position;
				Quaternion spawnRotation = Quaternion.identity;
				GameObject newCharacter = Instantiate(treePreFab, spawnPosition, spawnRotation) as GameObject;
				newCharacter.transform.LookAt(world.transform);
				newCharacter.transform.Rotate(-90, 0, 0);
			}
		}
	}
}
