﻿using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		this.gameObject.SetActive (false);
		Application.LoadLevel ("combined");
	}
}
