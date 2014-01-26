using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public float sloMoRate = 0.1f;
	private bool gameHasEnded = false;
	private CarControl[] cars;

	void OnGameEnd(){
		gameHasEnded = true;
		StartCoroutine(End());
	}

	void Start(){
		cars = GameObject.FindObjectsOfType<CarControl>() as CarControl[];
	}

	void Update(){
		if(gameHasEnded){
			foreach(CarControl car in cars){
				car.moveSpeed *= 1.0f - ((1.0f - sloMoRate) * Time.deltaTime);
			}
		}
	}

	IEnumerator End(){
		yield return new WaitForSeconds(3.0f);
		Debug.Log("Go To Next Scene");
		Application.LoadLevel("EndScreen");
	}
}
