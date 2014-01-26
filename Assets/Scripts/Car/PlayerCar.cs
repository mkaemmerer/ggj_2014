using UnityEngine;
using System.Collections;

public class PlayerCar : MonoBehaviour {
	
	public float turnSensitivity = 1.0f;
	private CarControl control;

	public float minTurnSpeed = 0.5f;
	public float maxTurnSpeed = 0.7f;
	public float screechThresh = 0.65f;
	public float turnAcceleration = 0.1f;

	public float curTurnSpeed = 0.0f;
	private float lastDir = 0.0f;
	
	void Start(){
		control = gameObject.GetComponent<CarControl>();
		curTurnSpeed = minTurnSpeed;
	}
	
	void Update(){
		if (Input.GetAxis ("Horizontal") == lastDir && lastDir != 0.0f) {
			curTurnSpeed = Mathf.Min (maxTurnSpeed, curTurnSpeed + turnAcceleration * Time.deltaTime);
		} else {
			curTurnSpeed = minTurnSpeed;
		}
		lastDir = Input.GetAxis ("Horizontal");

		if (curTurnSpeed >= screechThresh) {
			BroadcastMessage ("OnSharpTurnBegin", SendMessageOptions.DontRequireReceiver);
		} else {
			BroadcastMessage("OnSharpTurnEnd", SendMessageOptions.DontRequireReceiver);
		}

		float accel = Input.GetButton("Accelerate") ? 1.0f : 0.01f;
		float turn  = Input.GetAxis("Horizontal") * turnSensitivity * curTurnSpeed;
		Vector3 target = Vector3.RotateTowards(transform.forward, transform.right, turn, 0.0f) * accel;
		
		control.SendMessage("OnDrive", target);
	}
}
