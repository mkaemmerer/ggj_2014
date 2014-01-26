using UnityEngine;
using System.Collections;

public class ShowSky : MonoBehaviour {

	public Material[] skyboxes;
	private Camera cam;
	private Skybox skybox;
	
	void Awake(){
		cam    = gameObject.GetComponent<Camera>();
		skybox = gameObject.GetComponent<Skybox>();

		SetSky(LayerMask.NameToLayer("Channel 1"));
	}
	
	void OnChannelChange (LayerMask layer) {
		SetSky(layer);
	}

	void SetSky(LayerMask layer){
		int index = GetIndex (layer);
		skybox.material = skyboxes[index];
	}

	int GetIndex(LayerMask layer){
		if(layer == LayerMask.NameToLayer("Channel 1")){
			return 0;
		}
		if(layer == LayerMask.NameToLayer("Channel 2")){
			return 1;
		}
		if(layer == LayerMask.NameToLayer("Channel 3")){
			return 2;
		}
		return 0;
	}
}
