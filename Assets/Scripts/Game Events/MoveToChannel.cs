using UnityEngine;
using System.Collections;

public class MoveToChannel : MonoBehaviour {
	
	void OnChannelChange (LayerMask newChannel) {
		gameObject.layer = newChannel;
	}
}
