using UnityEngine;
using System.Collections;

public class Timerkeeper : MonoBehaviour {

	public float gameLength;
	private float elapsedTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if(elapsedTime >= gameLength){
			BroadcastMessage("TimeUp");
			GameObject.FindWithTag ("MainCamera").SendMessage ("TimeUp");

			enabled = false;
		}
	
	}
	void StartGame(){
		enabled=true;
	}
}
