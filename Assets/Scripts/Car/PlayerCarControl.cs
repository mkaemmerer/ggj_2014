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

		float haxis = Input.GetAxis ("Horizontal");
		float vaxis = Input.GetAxis ("Vertical");
		bool goForward = vaxis > 0;
		bool goBack = vaxis < 0;

		// Faster the car goes, smaller the multiplier.
		float maxWheelRotate = 45 * 1;
		float reverseMultiplier = .4f;

		bool onGround = true;

		if (onGround && goForward)
			rigidbody.AddForce (transform.forward * (forwardForce * timeMultiplier));
		else if (onGround && goBack)
			rigidbody.AddForce (transform.forward * (-forwardForce * timeMultiplier * reverseMultiplier));

		transform.Rotate (Vector3.up, haxis * maxWheelRotate * timeMultiplier, Space.Self);
	}
}
