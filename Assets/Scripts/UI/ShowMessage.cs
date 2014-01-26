using UnityEngine;
using System.Collections;

public class ShowMessage : MonoBehaviour {
	void OnGetRemote(){
		BroadcastMessage("OnShowMessage");
	}
}
