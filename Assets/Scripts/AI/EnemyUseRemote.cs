using UnityEngine;
using System.Collections;

public class EnemyUseRemote : MonoBehaviour {

	public float seconds = 10.0f;
	public bool hasRemote = true;

	private ChannelManager manager;
	
	void Start () {
		manager = GameObject.FindObjectOfType<ChannelManager>() as ChannelManager;

		StartCoroutine(UseRemote());
	}
	void OnStealRemote(){
		hasRemote = false;
	}

	//Change channel every time the timer expires
	IEnumerator UseRemote () {
		if(hasRemote){
			yield return new WaitForSeconds(seconds);
			ChangeChannel();
			StartCoroutine(UseRemote());
		}
	}
	void ChangeChannel(){
		manager.ChangeChannel();
	}
}
