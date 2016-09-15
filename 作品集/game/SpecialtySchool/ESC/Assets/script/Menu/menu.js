#pragma strict


var backgroundImage : Texture;
var screenMode = 0;
var textSpeed = 0;
var soundLevel = 0;


function Start () {
Time.timeScale = 0;
}

function Update(){
Time.timeScale = 0;
}

function Awake () {
		Time.timeScale = 0;
}

function OnDestroy () {
		Time.timeScale = 1;
}

function OnGUI () {
	if (GUI.Button (Rect(20, 200, 100, 30), "ゲームに戻る")) {
		Destroy(this.gameObject);	
	}

	if(GUI.Button (Rect(140, 200, 100, 30), "Title")){
		Application.LoadLevel("title");
		
	}
	if(GUI.Button (Rect(260, 200, 100, 30), "Retry")){
		Application.LoadLevel("gazou");
		Destroy(this.gameObject);
	}
}