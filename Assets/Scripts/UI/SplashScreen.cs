using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public GameObject nextScreen;

	void OnMouseDown() {
		this.gameObject.SetActive (false);
		nextScreen.SetActive (true);
	}
}
