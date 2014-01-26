using UnityEngine;
using System.Collections;

public class ObstacleSounds : MonoBehaviour {

	public AudioSource output;
	public float collisionSoundLength = 1.0f;

	private float collisionTime = 0.0f;
	
	// Update is called once per frame
	void Update () {
		if (collisionTime != 0.0f) {
			collisionTime = Mathf.Max (0.0f, collisionTime - Time.deltaTime);
		} else if (output.isPlaying) {
			output.Stop();
		}
	}

	void OnCollisionEnter()
	{
		output.time = Random.Range (0.0f, 1.0f);
		output.Play ();
		collisionTime = collisionSoundLength;
	}
}
