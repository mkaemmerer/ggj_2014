using UnityEngine;
using System.Collections;

public class CarSounds : MonoBehaviour {

	public AudioSource engineOutput;
	public AudioSource tireOutput;
	public float squealMin;
	public float squealMax;

	private float squealTime = 0.0f;

	// Use this for initialization
	void Start () {
		engineOutput.Play ();
	}

	void Update() {
		if (squealTime != 0.0f) {
			squealTime = Mathf.Max (0.0f, squealTime - Time.deltaTime);
		} else if (tireOutput.isPlaying) {
			tireOutput.Stop();
		}
	}

	void OnSharpTurn()
	{
		tireOutput.time = Random.Range (0.0f, tireOutput.clip.length);
		tireOutput.Play();
		squealTime = Random.Range (squealMin, squealMax);
	}
}
