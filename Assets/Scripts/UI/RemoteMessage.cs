using UnityEngine;
using System.Collections;

public class RemoteMessage : MonoBehaviour {

	public GameObject message;

	void OnShowMessage() {
		StartCoroutine(Show());
	}

	IEnumerator Show(){
		//Show message
		message.SetActive(true);
		//Wait
		yield return new WaitForSeconds(4.0f);
		//Hide message
		message.SetActive(false);
	}
}
