using UnityEngine;
using System.Collections;

public class ChannelManager : MonoBehaviour {

	private LayerMask currentLayer;
	private LayerMask currentGhostLayer;

	public LayerMask CurrentLayer {
		get{ return currentLayer; }
	}

	private void Awake (){
		currentLayer      = LayerMask.NameToLayer("Channel 1");
		currentGhostLayer = LayerMask.NameToLayer("Channel 2 Ghost");
	}

	public void ChangeChannel () {
		currentLayer = GetNextLayer();
		currentGhostLayer = GetNextGhostLayer();

		BroadcastMessage("OnChannelChange", currentLayer, SendMessageOptions.DontRequireReceiver);
		BroadcastMessage("OnGhostChannelChange", currentGhostLayer, SendMessageOptions.DontRequireReceiver);
	}

	private LayerMask GetNextLayer(){
		if(currentLayer == LayerMask.NameToLayer("Channel 1")){
			return LayerMask.NameToLayer("Channel 2");
		}
		if(currentLayer == LayerMask.NameToLayer("Channel 2")){
			return LayerMask.NameToLayer("Channel 3");
		}
		if(currentLayer == LayerMask.NameToLayer("Channel 3")){
			return LayerMask.NameToLayer("Channel 1");
		}
		return currentLayer;
	}

	private LayerMask GetNextGhostLayer(){
		if(currentLayer == LayerMask.NameToLayer("Channel 1 Ghost")){
			return LayerMask.NameToLayer("Channel 2 Ghost");
		}
		if(currentLayer == LayerMask.NameToLayer("Channel 2 Ghost")){
			return LayerMask.NameToLayer("Channel 3");
		}
		if(currentLayer == LayerMask.NameToLayer("Channel 3 Ghost")){
			return LayerMask.NameToLayer("Channel 1 Ghost");
		}
		return currentGhostLayer;
	}
}
