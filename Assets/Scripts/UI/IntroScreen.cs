using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour {

	void OnMouseDown () {
		this.gameObject.SetActive (false);
		Application.LoadLevel ("Combined");
	}
}
