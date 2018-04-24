using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour {

	public GameObject treePreFab;
	public GameObject healthPoint;
	public Sprite[] plantSprites; //ordered from least to most complex
	public float[] secondsToPlant = {1.0f,2.0f,3.0f};
	public float[] secondsToGenerate = { 3.0f, 6.0f, 9.0f }; //this should change based on the level
	public float[] increaseY = { .9f, 1.4f, 2.4f };
	ScoreManager score_script;

	// Use this for initialization
	void Start () {
		score_script =  GameObject.Find("Main Camera").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float newPlant(Vector3 playerPos, int plantIndex)
	{
		Vector3 spawnPos = playerPos;
		spawnPos.y -= 2f;
		//if level one, only let them do one plant. Level 2, let them do two. Level 3, let them do 3.
		Vector3 healthPos = Vector3.zero;
		healthPos.x -= .75f;
		healthPos.y += increaseY [plantIndex];


		GameObject newPlant = Instantiate<GameObject> (treePreFab);
		newPlant.GetComponent<SpriteRenderer>().sprite = plantSprites[plantIndex];
		//figure out which plant it is, give it that much health
		for (int i = plantIndex; i >= 0; i--) {
			GameObject newHealth = Instantiate<GameObject> (healthPoint);
			newHealth.transform.parent = newPlant.transform;
			healthPos.x += (1f / 2.3f);
			newHealth.transform.position = healthPos;
		}
		newPlant.transform.position = spawnPos;
		PlanetHealthManager.treePreFab.Add (newPlant);
		score_script.AddPlantScore (plantIndex);

		return secondsToPlant [plantIndex];
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
