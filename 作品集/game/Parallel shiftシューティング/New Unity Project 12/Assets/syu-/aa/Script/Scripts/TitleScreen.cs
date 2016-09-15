using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	public GUISkin skin;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0)){
			Application.LoadLevel ("Main");
	}
}
	void OnGUI(){
		int sw    = Screen.width;
		int sh    = Screen.height;
		GUI.skin  = skin;
		

		GUI.Label(new Rect(0,0,sw,sh),"SHOOTING GAME","Message");
		GUI.Label(new Rect(0,sh/2,sw,sh/2),"Click to Staet","Message");
	}
}