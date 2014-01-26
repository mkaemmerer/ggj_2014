using UnityEngine;
using System.Collections;
using System.Linq;

public class FollowRoad : MonoBehaviour {
	public float minDistance = 10.0f;

	private CarControl control;
	private Vector3 target;
	private ChannelManager manager;
	
	private void Start () {
		control = gameObject.GetComponent<CarControl>();
		manager = GameObject.FindObjectOfType<ChannelManager>() as ChannelManager;
		target  = GetNextTarget();
	}

	private void Update () {
		Vector3 direction = target - gameObject.transform.position;
		control.SendMessage("OnDrive", direction);
	}

	void OnTriggerEnter(){
		target = GetNextTarget();
	}

	private Vector3 GetNextTarget(){
		GameObject closestCheckpoint = null;
		float closestDistance = 1.0f/0.0f; //Infinity

		GameObject[] checkpoints = GetCheckpoints();
		foreach(GameObject checkpoint in checkpoints){
			float distance = (transform.position - checkpoint.transform.position).magnitude;

			if(distance < closestDistance && distance > minDistance){
				closestCheckpoint = checkpoint;
				closestDistance   = distance;
			}
		}

		if(closestCheckpoint != null){
			return closestCheckpoint.transform.position;
		} else {
			return transform.position;
		}
	}

	private GameObject[] GetCheckpoints(){
		GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
		return checkpoints
			//Only look at checkpoints on the current layer
			.Where(obj => obj.layer == manager.CurrentLayer.value)
			//Only look at checkpoints that are ahead of us
			.Where(obj => Vector3.Dot(obj.transform.position - transform.position, transform.forward) > 0)
			.ToArray();
	}
}
