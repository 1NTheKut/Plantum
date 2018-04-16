using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Garbage : MonoBehaviour {

	public static float bottomY = -20f;
	GameObject player;
	PlayerHealth playerHealth_script;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerHealth_script = player.GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		//delete apples if they fall off screen
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
			//Debug.Log("Hit player");
			playerHealth_script.removeHealth(this.gameObject);
		} else if (collidedWith.tag == "tree") {
			PlanetHealthManager.treePreFab.Remove (collidedWith);
			Destroy (this.gameObject);
			Destroy (collidedWith);
		}
	}
}
