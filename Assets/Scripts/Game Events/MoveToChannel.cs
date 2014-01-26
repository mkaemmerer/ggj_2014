using UnityEngine;
using System.Collections;

public class MoveToChannel : MonoBehaviour {
	
	void OnChannelChange (LayerMask newChannel) {
		SetLayerRecursively(gameObject, newChannel);
	}

	void SetLayerRecursively(GameObject obj, LayerMask newLayer)
	{
		obj.layer = newLayer;
		foreach(Transform child in obj.transform ){
			SetLayerRecursively(child.gameObject, newLayer);
		}
	}
}
