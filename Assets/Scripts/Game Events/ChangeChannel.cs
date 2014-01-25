using UnityEngine;
using System.Collections;

public class ChangeChannel : MonoBehaviour {

	private ChannelManager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindObjectOfType<ChannelManager>() as ChannelManager;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			manager.ChangeChannel();
		}
	}
}
