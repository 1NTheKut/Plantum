using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour {

	public GameObject treePreFab;
	public GameObject healthPoint;
	public Sprite[] plantSprites; //ordered from least to most complex
	public float[] secondsToPlant = {1.0f,2.0f,3.0f};
	public float[] increaseY = { .9f, 1.4f, 2.4f };
	int spriteRandomizer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float newPlant(Vector3 playerPos)
	{
		Vector3 spawnPos = playerPos;
		spawnPos.y -= 2f;
		//if level one, only let them do one plant. Level 2, let them do two. Level 3, let them do 3.
		spriteRandomizer = Random.Range (0,plantSprites.Length);
		Vector3 healthPos = Vector3.zero;
		healthPos.x -= .75f;
		healthPos.y += increaseY [spriteRandomizer];


		GameObject newPlant = Instantiate<GameObject> (treePreFab);
		newPlant.GetComponent<SpriteRenderer>().sprite = plantSprites[spriteRandomizer];
		//figure out which plant it is, give it that much health
		for (int i = spriteRandomizer; i >= 0; i--) {
			GameObject newHealth = Instantiate<GameObject> (healthPoint);
			newHealth.transform.parent = newPlant.transform;
			healthPos.x += (1f / 2.3f);
			newHealth.transform.position = healthPos;
		}
		newPlant.transform.position = spawnPos;
		PlanetHealthManager.treePreFab.Add (newPlant);

		return secondsToPlant [spriteRandomizer];
	}

	public void removeHealth(GameObject plant)
	{
		SpriteRenderer[] health_sprites = plant.GetComponentsInChildren<SpriteRenderer> ();
		int currentLives = health_sprites.Length - 1;
		if (currentLives > 0) {
			//health_sprites [currentLives-1].enabled = false;
			Destroy(health_sprites [currentLives-1]);
			currentLives--;
			if (currentLives == 0) {
				Destroy (plant);
			}
		} else {
			Destroy (plant);
		}
	}
}
