using UnityEngine;
using System.Collections;

public class SoundTrack : MonoBehaviour {

	public AudioClip[] tracks;
	public AudioSource output;
	public AudioSource changeSound;

	// Use this for initialization
	void Start () {
		output.clip = tracks [0];
		output.Play ();
	}

	void OnChannelChange(LayerMask newLayer)
	{
		string layer = LayerMask.LayerToName (newLayer);
		float progress = 0.0f;

		if(output.clip)
		{
			progress = output.time / output.clip.length;
		}

		switch (layer) {
		case "Channel 1":
			output.clip = tracks[0];
			break;
		case "Channel 2":
			output.clip = tracks[1];
			break;
		case "Channel 3":
			output.clip = tracks[2];
			break;
		default:
			return;
		}

		changeSound.Play ();

		output.time = progress * output.clip.length + 0.2f;
		output.PlayDelayed (0.2f);
	}
}
