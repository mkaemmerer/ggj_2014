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

		float vaxis = Input.GetAxis ("Vertical");
		float haxis = Input.GetAxis ("Horizontal");

		// Faster the car goes, smaller the multiplier.
		float maxWheelRotate = 45 * 1;
		float reverseMultiplier = .4f;

		bool onGround = true;

		// The care is backward-facing, throwing in -1 for now.
		if (onGround){
			rigidbody.AddRelativeForce (transform.forward * (vaxis*forwardForce * timeMultiplier));
		}

		rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.forward), haxis * timeMultiplier));
//		rigidbody.MoveRotation(Vector3.up, haxis * maxWheelRotate * timeMultiplier, Space.Self);
	}
}
