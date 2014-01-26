using UnityEngine;
using System.Collections;

public class StealRemote : MonoBehaviour {
	
	private bool hasRemote = false;

	void OnCollisionEnter(Collision collision){
		if(hasRemote) return;

		EnemyUseRemote enemy = collision.gameObject.GetComponent<EnemyUseRemote>();
		if(enemy != null && enemy.hasRemote){
			enemy.SendMessage("OnStealRemote");
			hasRemote = true;

			//Now we can change the channel
			gameObject.AddComponent("ChangeChannel");
		}
	}
}
