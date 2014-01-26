using UnityEngine;
using System.Collections;

public class CarSounds : MonoBehaviour {

	public AudioSource engineOutput;
	public AudioSource tireOutput;

	// Use this for initialization
	void Start () {
		engineOutput.Play ();
	}

	void OnSharpTurnBegin()
	{
		if (!tireOutput.isPlaying) {
			tireOutput.time = Random.Range (0.0f, tireOutput.clip.length);
			tireOutput.Play ();
		}
	}

	void OnSharpTurnEnd()
	{
		if (tireOutput.isPlaying) {
			tireOutput.Stop ();
		}
	}
}
