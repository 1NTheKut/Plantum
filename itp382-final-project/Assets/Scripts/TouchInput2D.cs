using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput2D : MonoBehaviour {

	public GameObject treePreFab;
	public GameObject player;
	bool isFreePos;
	bool canPlantSeed = false;
	float timeSinceLastSeed;
	float seedWaitTime = 3.0f;
	public bool isPlanting; //used to see if player can move or not: need to get this variable in MovePlayer and have it hold movement for 3 seconds

	[Header("Set Dynamically")]
	public Text seedReadyText;
	public Text seedText;
	public int numSeeds= 10;

	public float swipeThreshold;
	private Vector2 startPos;

	Move2DPlayer character;


	// Use this for initialization
	void Start () {
		//begin delay
		bool supportsMultiTouch = Input.multiTouchEnabled;
		if (!supportsMultiTouch) {
			print ("Multitouch not supported");
		}
		isFreePos = true;
		player = GameObject.Find("Player");

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
					startPos = touch.position;
					if (numSeeds > 0 && canPlantSeed) {
						PlantTree ();
					}
				} else if (touch.phase == TouchPhase.Ended) {
					Move2DPlayer swipedPlayer = player.GetComponent<Move2DPlayer> ();
					float swipteDist = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
					if (swipteDist == swipeThreshold) {
						float swipeValue = Mathf.Sign (touch.position.x - startPos.x);
						if (swipeValue > 0) {				
							swipedPlayer.ChangeDirection ();
							Debug.Log ("Right");
						} else if (swipeValue < 0) {
							swipedPlayer.ChangeDirection ();
							Debug.Log ("Left");
						}

					}
				}

			}
		} else if (Input.GetMouseButtonDown (0)) {
			if (numSeeds > 0 && canPlantSeed) {
				PlantTree ();
			}

		} 
		isFreePos = true;

		//***handle swiping to change direction***
		//if swipe detected, then change direction
		//Move2DPlayer moveScript = player.GetComponent<Move2DPlayer> ();
		//moveScript.ChangeDirection();
	}

	void PlantTree() {
		Move2DPlayer movePlayer = player.GetComponent<Move2DPlayer> ();
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
			StartCoroutine(movePlayer.PlayerIsPlanting ());
			Vector3 spawnPos = player.transform.position;
			spawnPos.y -= .5f;
			GameObject newPlant = Instantiate<GameObject> (treePreFab);
			newPlant.transform.position = spawnPos;
		}
		numSeeds--;
		movePlayer.PlayerDonePlanting ();
		canPlantSeed = false;
		timeSinceLastSeed = 0;
		seedReadyText.text = "Generating seed.";
	}
}