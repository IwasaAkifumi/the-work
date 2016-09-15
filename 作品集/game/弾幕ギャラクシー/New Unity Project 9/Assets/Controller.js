#pragma strict

function Start () {

}

function Update () {
  	 if (Input.GetKey(KeyCode.Joystick1Button1)) {
  	 if(Title.i == 0){
  	 Application.LoadLevel("menu");
  	 }else if(Title.i == 1){
  	 Application.LoadLevel("StageE");
  	 }
  	 }
  	 
  	 if (Input.GetKey(KeyCode.Joystick1Button2)) {
  	 Application.LoadLevel("title");
  	 }

}