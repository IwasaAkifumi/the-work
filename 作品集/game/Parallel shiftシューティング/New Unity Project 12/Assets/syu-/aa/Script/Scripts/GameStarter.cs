using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour {

	public GUISkin skin;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = 3.5f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer < 0.0f){

			BroadcastMessage("StartGame");
			enabled = false;
	
	}
}
	void OnGUI(){
		if(timer > 3.0 || timer <= 0.0)return;

		int sw    = Screen.width;
		int sh    = Screen.height;
		GUI.skin  = skin;

		string text = Mathf.CeilToInt (timer).ToString ();
		GUI.color = new Color(1,1,1,timer -  Mathf.FloorToInt (timer));
		GUI.Label(new Rect(0,sh/4,sw,sh/2),text,"CountDown");
	}
}
