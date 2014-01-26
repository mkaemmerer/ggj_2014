using UnityEngine;
using System.Collections;

public class ShowChannel : MonoBehaviour {

	private Camera cam;

	void Start(){
		cam = gameObject.GetComponent<Camera>();
	}

	void OnChannelChange (LayerMask layer) {
		cam.cullingMask = 1 << layer;
	}
	void OnGhostChannelChange (LayerMask layer) {
		cam.cullingMask = cam.cullingMask | (1 << layer);
	}
}
