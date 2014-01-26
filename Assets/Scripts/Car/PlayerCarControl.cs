using UnityEngine;
using System.Collections;

public class PlayerCarControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		const float forwardForce = 600;
		float timeMultiplier = Time.deltaTime;

		bool goForward = Input.GetKey (KeyCode.W);
		bool goBack = Input.GetKey (KeyCode.S);
		float haxis = Input.GetAxis ("Horizontal");

		// Faster the car goes, smaller the multiplier.
		float maxWheelRotate = 90 * 1;
		float reverseMultiplier = .6f;

		bool onGround = true;

		// The car is backward-facing, throwing in -1 for now.
		if (onGround && goForward)
			rigidbody.AddRelativeForce (transform.forward * (-1*forwardForce * timeMultiplier));
		else if (onGround && goBack)
			rigidbody.AddRelativeForce (transform.forward * (-1*-forwardForce * timeMultiplier * reverseMultiplier));

		float radians = haxis * maxWheelRotate * (Mathf.PI/180f);
		float lateral = (rigidbody.velocity.magnitude * Mathf.Sin (radians));

		transform.Rotate (Vector3.forward, haxis * maxWheelRotate * timeMultiplier, Space.Self);
		//transform.Translate (Vector3.right * lateral * timeMultiplier, Space.Self);
		//rigidbody.velocity.RotateAroundPoint (transform.position, radians);
		rigidbody.velocity = rigidbody.velocity.RotateAroundPoint (Vector3.zero, radians * timeMultiplier);
	}

}
