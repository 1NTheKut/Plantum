using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Garbage : MonoBehaviour {

	public static float bottomY = -20f;

	// Use this for initialization
	void Start () {
		
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
			Destroy (this.gameObject);
			SceneManager.LoadScene ("LoseScene");
			//comment this out if you don't want game to end when space junk hits player
		} else if (collidedWith.tag == "tree") {
			PlanetHealthManager.treePreFab.Remove (collidedWith);
			Destroy (this.gameObject);
			Destroy (collidedWith);
		}
	}
}
