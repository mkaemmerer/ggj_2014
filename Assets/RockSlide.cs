using UnityEngine;
using System.Collections;

public class RockSlide : MonoBehaviour {

	public float minForce = 200;
	public float maxForce = 600;
	public int rockNum = 10;
	public GameObject rock;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		GameObject newRock;

		for (int i = 0; i < rockNum; i++) {
			newRock = Instantiate (rock) as GameObject;
			newRock.rigidbody.AddForce(-transform.forward * Random.Range(200, 600));
			newRock.rigidbody.useGravity = true;
		}
	}
}
