using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Garbage : MonoBehaviour {

	public static float bottomY = -20f;
	GameObject player;
	GameObject plantManager;
	PlayerHealth playerHealth_script;
	PlantManager plantHealth_script;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		plantManager = GameObject.Find ("PlantManager");
		playerHealth_script = player.GetComponent<PlayerHealth> ();
		plantHealth_script = plantManager.GetComponent<PlantManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < bottomY) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D( Collider2D coll )
	{
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "ground") {
			Destroy (this.gameObject);
		} else if (collidedWith.tag == "Player") {
			playerHealth_script.removeHealth(this.gameObject);
		} else if (collidedWith.tag == "tree") {
			plantHealth_script.removeHealth(collidedWith);
			PlanetHealthManager.treePreFab.Remove (collidedWith);
			Destroy (this.gameObject);

		}
	}
}
