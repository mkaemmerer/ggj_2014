using UnityEngine;
using System.Collections;

public class FollowRoad : MonoBehaviour {
	public GameObject[] checkpoints;

	private CarControl control;
	private Vector3 target;
	private int index = 0;
	
	void Start () {
		control = gameObject.GetComponent<CarControl>();
		target  = GetNextTarget();
	}

	void Update () {
		Vector3 direction = target - gameObject.transform.position;
		control.SendMessage("OnDrive", direction);
	}

	void OnTriggerEnter(){
		target = GetNextTarget();
	}

	Vector3 GetNextTarget(){
		Vector3 target = checkpoints[index].transform.position;
		if(++index >= checkpoints.Length){
			index = 0;
		}
		return target;
	}
}
