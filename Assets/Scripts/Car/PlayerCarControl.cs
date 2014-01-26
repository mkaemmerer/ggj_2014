using UnityEngine;
using System.Collections;

public class PlayerCarControl : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	public float forwardForce = 600;
	
	// Update is called once per frame
	void Update () {
		
		float timeMultiplier = Time.deltaTime;
		
		bool goForward = Input.GetKey (KeyCode.W);
		bool goBack = Input.GetKey (KeyCode.S);
		float haxis = Input.GetAxis ("Horizontal");
		
		// Faster the car goes, smaller the multiplier.
		float maxWheelRotate = 90 * 1;
		float reverseMultiplier = .9f;
		
		bool onGround = true;
		
		if (!onGround)
			return;
		
		// The car is backward-facing, throwing in -1 for now.
		if (goForward)
			rigidbody.AddRelativeForce (transform.forward * (-1*forwardForce * timeMultiplier));
		else if (goBack)
			rigidbody.AddRelativeForce (transform.forward * (-1*-forwardForce * timeMultiplier * reverseMultiplier));
		
		if (rigidbody.velocity.magnitude < 0.05)
			return;
		
		float radians = haxis * maxWheelRotate * (Mathf.PI/180f);
		float rev = 1;//(goBack ? -1 : 1);
		//float lateral = (rigidbody.velocity.magnitude * Mathf.Sin (radians));
		
		transform.Rotate (Vector3.forward, rev * haxis * maxWheelRotate * timeMultiplier, Space.Self);
		//transform.Translate (Vector3.right * lateral * timeMultiplier, Space.Self);
		//rigidbody.velocity.RotateAroundPoint (transform.position, radians);
		rigidbody.velocity = rigidbody.velocity.RotateAroundPoint (Vector3.zero, rev * radians * timeMultiplier);
		//Debug.Log ("velocity: " + rigidbody.velocity);
		//Debug.Log ("this.transform.forward: " + this.transform.forward);
		//Debug.Log ("transformdirection: " + transform.TransformDirection(transform.forward));
	}
	
}
