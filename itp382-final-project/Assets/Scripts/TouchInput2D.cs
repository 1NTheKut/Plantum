using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput2D : MonoBehaviour {


	public GameObject player;
	GameObject plantManager;
	bool isFreePos;
	bool canPlantSeed = false;
	float timeSinceLastSeed;
	float seedWaitTime = 3.0f;

	public bool isPlanting; //used to see if player can move or not: need to get this variable in MovePlayer and have it hold movement for 3 seconds

	[Header("Set Dynamically")]
	public Text seedReadyText;

	public float sensitivity = 0.5f;
	public float swipeThreshold;
	private Vector2 startPos;

	Move2DPlayer moveCharacter;
	PlantManager managePlant;

	//private float ScreenWidth;

	public Button plantButton;

	// Use this for initialization
	void Start () {
		//begin delay
		//ScreenWidth = Screen.width;
		bool supportsMultiTouch = Input.multiTouchEnabled;
		if (!supportsMultiTouch) {
			print ("Multitouch not supported");
		}
		isFreePos = true;
		player = GameObject.Find("Player");
		plantManager = GameObject.Find ("PlantManager");


		GameObject seedReadyGO = GameObject.Find ("SeedReady");
		seedReadyText = seedReadyGO.GetComponent<Text> ();
		seedReadyText.text = "Generating seed.";

		timeSinceLastSeed = 0;
		isPlanting = false;

		moveCharacter = player.GetComponent<Move2DPlayer> ();
		managePlant = plantManager.GetComponent<PlantManager> ();
	}

	// Update is called once per frame
	void Update () {
		//seedText.text = "Seeds Left: " + numSeeds.ToString ();

		//Timer:
		timeSinceLastSeed += Time.deltaTime;
		if (timeSinceLastSeed > seedWaitTime) {
			//set plant seed to tru
			canPlantSeed = true;
			//change text
			seedReadyText.text = "Seed Ready to Plant.";
		}


		Button plant = plantButton.GetComponent<Button> ();
			if (canPlantSeed) { //numSeeds > 0 &&
			 plant.onClick.AddListener (PlantTree);
				//PlantTree ();
			}

		isFreePos = true;

	}

	void FixedUpdate(){
		#if UNITY_EDITOR
		moveCharacter.ChangeDirection(Input.GetAxis("Horizontal"));
		#endif

	}

	void PlantTree() {
		player.GetComponent<Animator> ().SetBool ("isWalking", false);
		player.GetComponent<Animator> ().SetBool ("isPlanting", true);
		foreach(GameObject plantedTree in GameObject.FindGameObjectsWithTag("tree"))
		{
			if(Mathf.Round(player.transform.position.x) == Mathf.Round(plantedTree.transform.position.x))
			{
				isFreePos = false;
			}
		}
		if (isFreePos) {
			//CALLING PLANT CLASS HERE
			float plantTime = managePlant.newPlant(player.transform.position);
			StartCoroutine(moveCharacter.PlayerIsPlanting (plantTime)); 

		}
		//numSeeds--;
		moveCharacter.PlayerDonePlanting ();

		canPlantSeed = false;
		timeSinceLastSeed = 0;
		seedReadyText.text = "Generating seed.";

		//Debug.Log ("Planted");
	}
}


