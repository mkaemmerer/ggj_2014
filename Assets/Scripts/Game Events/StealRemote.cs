using UnityEngine;
using System.Collections;

public class StealRemote : MonoBehaviour {
	
	private bool hasRemote = false;

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("Enemy")){
			//If we don't have the remote, try to steal it back
			if(!hasRemote){
				Steal(collision.gameObject);
			}
			//Otherwise, defeat the enemy!
			else {
				Defeat (collision.gameObject);
			}
		}
	}

	void Steal(GameObject enemy){
		EnemyUseRemote enemyRemote = enemy.GetComponent<EnemyUseRemote>();
		enemyRemote.SendMessage("OnStealRemote");
		hasRemote = true;
		//Now we can change the channel
		gameObject.AddComponent("ChangeChannel");
	}

	void Defeat(GameObject enemy){
		gameObject.SendMessageUpwards("OnGameEnd");
	}
}
