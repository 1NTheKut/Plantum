using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput2D : MonoBehaviour {

	public GameObject treePreFab;
	GameObject world;
	GameObject player;
	bool isFreePos;
	bool canPlantSeed = false;
	float timeSinceLastSeed;
	float seedWaitTime = 6.0f;
	public bool isPlanting; //used to see if player can move or not: need to get this variable in MovePlayer and have it hold movement for 3 seconds

	[Header("Set Dynamically")]
	public Text seedReadyText;
	public Text seedText;
	public int numSeeds;



	// Use this for initialization
	void Start () {
		bool supportsMultiTouch = Input.multiTouchEnabled;
		if (!supportsMultiTouch) {
			print ("Multitouch not supported");
		}
		isFreePos = true;
		world = GameObject.Find ("Planet");
		player = GameObject.Find("Player");

		numSeeds = 10;
		GameObject seedGO = GameObject.Find ("SeedCounter");
		GameObject seedReadyGO = GameObject.Find ("SeedReady");
		seedText = seedGO.GetComponent<Text> ();
		seedText.text = "Seeds Left: " + numSeeds.ToString ();
		seedReadyText = seedReadyGO.GetComponent<Text> ();
		seedReadyText.text = "Generating seed.";

		timeSinceLastSeed = 0;
		isPlanting = false;
	}

	// Update is called once per frame
	void Update () {
		seedText.text = "Seeds Left: " + numSeeds.ToString ();

		//Timer:
		timeSinceLastSeed += Time.deltaTime;
		if (timeSinceLastSeed > seedWaitTime) {
			//set plant seed to tru
			canPlantSeed = true;
			//change text
			seedReadyText.text = "Seed Ready to Plant.";
		}

		int nbTouches = Input.touchCount;
		if (nbTouches > 0) {
			for (int i = 0; i < nbTouches; i++) {
				Touch touch = Input.GetTouch (i);

				if (touch.phase == TouchPhase.Began) {
					//CheckSeeds ();
					if (numSeeds > 0 && canPlantSeed) {
						PlantTree ();
					}
				} 

			}
		} else if (Input.GetMouseButtonDown (0)) {
			if (numSeeds > 0 && canPlantSeed) {
				PlantTree ();
			}

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
			isPlanting = true;
			Vector3 spawnPos = player.transform.position;
			Quaternion spawnRotation = Quaternion.identity;
			spawnPos.z += 1;
			spawnPos.y -= .5f;
			GameObject newCharacter = Instantiate(treePreFab, spawnPos, spawnRotation) as GameObject;
			newCharacter.transform.LookAt(world.transform);
			newCharacter.transform.Rotate(-90, 0, 0);
		}
		numSeeds--;
		canPlantSeed = false;
		timeSinceLastSeed = 0;
		seedReadyText.text = "Generating seed.";
	}
}