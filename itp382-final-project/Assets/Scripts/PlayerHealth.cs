using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	SpriteRenderer[] health_sprites;
	public int maxLives = 3;
	int playerLives;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		health_sprites = player.GetComponentsInChildren<SpriteRenderer> ();
		playerLives = maxLives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void removeHealth(GameObject garbage) {
		if (playerLives > 0) {
			health_sprites [playerLives].enabled = false;
			Destroy (garbage);
			playerLives--;
			if (playerLives == 0) {
				SceneManager.LoadScene ("LoseScene_playerDied");
			}
		} else {
			//player lost
			SceneManager.LoadScene ("LoseScene_playerDied");
		}
	}
}
