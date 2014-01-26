using UnityEngine;
using System.Collections;

public class PlayerCar : MonoBehaviour {
	
	public float turnSensitivity = 1.0f;
	private CarControl control;
	
	void Start(){
		control = gameObject.GetComponent<CarControl>();
	}
	
	void Update(){
		float accel = Input.GetButton("Accelerate") ? 1.0f : 0.01f;
		float turn  = Input.GetAxis("Horizontal") * turnSensitivity;
		Vector3 target = Vector3.RotateTowards(transform.forward, transform.right, turn, 0.0f) * accel;
		
		control.SendMessage("OnDrive", target);
	}
}
