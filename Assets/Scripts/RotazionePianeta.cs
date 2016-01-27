using UnityEngine;
using System.Collections;

public class RotazionePianeta: MonoBehaviour {

	public float rotationSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		PlanetRotation ();


	}

	void PlanetRotation() {
//		transform.RotateAround(transform.position, Vector3.up , rotationSpeed); 
		transform.Rotate(0, rotationSpeed, 0, Space.Self);
	}
}
