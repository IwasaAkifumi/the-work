//タイトル画面
var labelStyle : GUIStyle;
var SE : AudioClip;
var SE2 : AudioClip;
static var i : int;
private var state : String;
private var state2 : String;

function Start () {

i = 0;
state = "stop";

}

function Update () {
 if (Input.GetAxis("axis3") == 1 && state == "stop" && state2 != "stop") { // 下ボタンが押された(押され続けは検知されない)
 audio.PlayOneShot(SE);
 i = (i + 1)%2;
 if(i==0){
 audio.PlayOneShot(SE);
 this.transform.position=Vector3(-60,1,-60);
 state = "start";
 Invoke( "Hoge2", 0.2 );
 }else if(i==1){
 audio.PlayOneShot(SE);
 this.transform.position=Vector3(-40,5,-90);
  state = "start";
 Invoke( "Hoge2", 0.2 );
 }
 }
 
 
 if (Input.GetAxis("axis3") == -1 && state == "stop" && state2 != "stop") { // 上ボタンが押された(押され続けは検知されない) 
 i = (i + 1)%2;
 audio.PlayOneShot(SE);
 if(i==0){
 audio.PlayOneShot(SE);
  this.transform.position=Vector3(-60,1,-60);
  state = "start";
  Invoke( "Hoge2", 0.2 );
 }else if(i==1){
 audio.PlayOneShot(SE);
 this.transform.position=Vector3(-40,1,-90);
 state = "start";
 Invoke( "Hoge2", 0.2 );
}
}
  
  if(Input.GetButtonDown("Jump")){
  state2 = "stop";
  audio.PlayOneShot(SE2);
  	Camera.main.SendMessage("fadeOut");
  	 Invoke( "Hoge", 2 );
  	 }
}
function Hoge() {
  switch(i){//現在選択中の状態によって処理を分岐
case 0://STAGEMODE
    Application.LoadLevel("controller");
	break;
case 1://VSMODE
	Application.LoadLevel("controller");

	}
}
function Hoge2() {
state = "stop";
}

