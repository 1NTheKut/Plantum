using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput2D : MonoBehaviour {


	public GameObject player;
	GameObject plantManager;
	bool isFreePos;
	bool canPlantSeed = false;
	float[] timesSinceLastSeed = { 0f, 0f, 0f };

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
	public Button[] plantButtons;


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
		for (int i = 0; i < 3; i++) {
			plantButtons [i].interactable = false;
		}

		isPlanting = false;

		moveCharacter = player.GetComponent<Move2DPlayer> ();
		managePlant = plantManager.GetComponent<PlantManager> ();
	}

	// Update is called once per frame
	void Update () {
		//seedText.text = "Seeds Left: " + numSeeds.ToString ();

		//Timer:
		for (int i = 0; i < 3; i++) {
			timesSinceLastSeed[i] += Time.deltaTime;
			if (timesSinceLastSeed [i] > managePlant.secondsToGenerate [i]) {
				canPlantSeed = true;
				plantButtons [i].interactable = true;
			}
		}
		if (canPlantSeed) {
			plantButtons [0].onClick.AddListener ( () => PlantTree( 0 ) );
			plantButtons [1].onClick.AddListener ( () => PlantTree( 1 ) );
			plantButtons [2].onClick.AddListener ( () => PlantTree( 2 ) );
		}


		isFreePos = true;

	}

	void FixedUpdate(){
		#if UNITY_EDITOR
		moveCharacter.ChangeDirection(Input.GetAxis("Horizontal"));
		#endif

	}

	void PlantTree(int plantIndex) {
		//Debug.Log ("In Plant Tree: " + plantIndex);
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
			float plantTime = managePlant.newPlant(player.transform.position, plantIndex);
			StartCoroutine(moveCharacter.PlayerIsPlanting (plantTime));

		}
		//numSeeds--;
		moveCharacter.PlayerDonePlanting ();

		canPlantSeed = false;
		timesSinceLastSeed[plantIndex] = 0f;
		plantButtons [plantIndex].interactable = false;

	}
}
