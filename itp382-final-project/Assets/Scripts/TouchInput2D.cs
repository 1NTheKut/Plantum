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
	public Sprite[] plantSprites;
	int spriteRandomizer;

	public bool isPlanting; //used to see if player can move or not: need to get this variable in MovePlayer and have it hold movement for 3 seconds

	[Header("Set Dynamically")]
	public Text seedReadyText;

	public float sensitivity = 0.5f;
	public float swipeThreshold;
	private Vector2 startPos;

	Move2DPlayer moveCharacter;

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


		GameObject seedReadyGO = GameObject.Find ("SeedReady");
		seedReadyText = seedReadyGO.GetComponent<Text> ();
		seedReadyText.text = "Generating seed.";

		timeSinceLastSeed = 0;
		isPlanting = false;

		moveCharacter = player.GetComponent<Move2DPlayer> ();
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

//
//		}
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
			StartCoroutine(moveCharacter.PlayerIsPlanting ());
			Vector3 spawnPos = player.transform.position;
			spawnPos.y -= 1.5f;
			GameObject newPlant = Instantiate<GameObject> (treePreFab);
			spriteRandomizer = Random.Range (0,plantSprites.Length);
			newPlant.GetComponent<SpriteRenderer>().sprite = plantSprites[spriteRandomizer];
			newPlant.transform.position = spawnPos;
			PlanetHealthManager.treePreFab.Add (newPlant);
		}
		//numSeeds--;
		moveCharacter.PlayerDonePlanting ();
		canPlantSeed = false;
		timeSinceLastSeed = 0;
		seedReadyText.text = "Generating seed.";

		//Debug.Log ("Planted");
	}
}

//		int i = 0;
//
//		while (i < Input.touchCount) {
//			if (Input.GetTouch (i).position.x > ScreenWidth / 2) {
//				moveCharacter.ChangeDirection (1.0f);
//			}if (Input.GetTouch (i).position.x < ScreenWidth / 2) {
//				moveCharacter.ChangeDirection (-1.0f);
//			}
//			++i;
//		}

//		int nbTouches = Input.touchCount;
//
//		//check for moved or stationary finger
//		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
//
//			//check for change in direction every frame
//			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
//
//			//if direction is greater than sensitivity (1.5), set the movement to right, also set mobileRight to true... this will allow movement with stationary finger
//			if (touchDeltaPosition.y > sensitivity) {
//				moveCharacter.ChangeDirection (1.0f);
//			}
//
//			//else check to see if direction of finger movement is less than -sensitivity (-1.5) if so set direction to left and mobileRight to false
//			else if (touchDeltaPosition.y < -sensitivity) {
//				moveCharacter.ChangeDirection (-1.0f);
//			}
//				
//		} else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
//			//check for change in direction every frame
//			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
//
//			//if touch direction is 0 (Finger NOT moving)
//			if (touchDeltaPosition.y == 0) {
//				if (canPlantSeed) { //(numSeeds > 0 &&
//					PlantTree ();
//				}
//			}
//		}
