using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public GameObject nextScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		this.gameObject.SetActive (false);
		nextScreen.SetActive (true);
	}
}
