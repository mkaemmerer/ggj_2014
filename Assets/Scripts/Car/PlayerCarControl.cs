using UnityEngine;
using System.Collections;

public class PlayerCarControl : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		const float forwardForce = 1000;
		float timeMultiplier = Time.deltaTime;

		bool goForward = Input.GetKey (KeyCode.W);
		bool goBack = Input.GetKey (KeyCode.S);
		float haxis = Input.GetAxis ("Horizontal");

		// Faster the car goes, smaller the multiplier.
		float maxWheelRotate = 45 * 1;
		float reverseMultiplier = .4f;

		bool onGround = true;

		// The care is backward-facing, throwing in -1 for now.
		if (onGround && goForward)
			rigidbody.AddRelativeForce (transform.forward * (-1*forwardForce * timeMultiplier));
		else if (onGround && goBack)
			rigidbody.AddRelativeForce (transform.forward * (-1*-forwardForce * timeMultiplier * reverseMultiplier));

		transform.Rotate (Vector3.forward, haxis * maxWheelRotate * timeMultiplier, Space.Self);
	}
}
