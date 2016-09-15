//Player1のボスの出現時の移動
#pragma strict
static var frame : int;

function Start () {
frame = 0;
}

function Update () {
if(Enemys.enemys >= 100 && frame != 500){
frame++;
transform.Translate(0,0,0.1);
}

}