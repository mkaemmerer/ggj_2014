using UnityEngine;
using System.Collections;

public class CarControl : MonoBehaviour {

	public float rotationSpeed = 1.0f;
	public float moveSpeed     = 1.0f;

	private Rigidbody body;
	private Vector3 direction;

	void Start(){
		body = gameObject.GetComponent<Rigidbody>();
	}

	void OnDrive(Vector3 dir){
		direction = dir;
	}

	void FixedUpdate(){
		body.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime));

		if(direction.magnitude > 0){
			Vector3 moveVector = transform.forward * moveSpeed * Time.deltaTime;
			body.MovePosition(transform.position + moveVector);
		}
	}
}
