using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkGravity : MonoBehaviour {

	PlanetScript attractorPlanet;
	private Transform playerTransform;
	GameObject planet;

	// Use this for initialization
	void Start () {
		planet = GameObject.Find ("Planet");
		attractorPlanet = planet.GetComponent<PlanetScript> ();
		GetComponent<Rigidbody> ().useGravity = false;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;

		playerTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if (attractorPlanet){
			attractorPlanet.Attract (playerTransform);
		}
	}
}
