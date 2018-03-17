using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {

	[SerializeField]
	Transform planet;

	private Rigidbody2D rigidBody;

	[SerializeField]
	float gravitationalPull;

	void Start(){
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		Vector2 transformDifference = planet.transform.position - this.transform.position;
		rigidBody.AddForce(transformDifference.normalized * gravitationalPull);
		float angle = Mathf.Atan2 (transformDifference.x, transformDifference.y);

		this.transform.rotation = Quaternion.AngleAxis (angle, transform.up);
	}

}
