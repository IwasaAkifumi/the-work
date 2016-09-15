//Player2のボスの出現時の移動
#pragma strict
static var frame2 : int;

function Start () {
frame2 = 0;
}

function Update () {
if(Enemys.enemys2 >= 100 && frame2 != 500){
frame2++;
transform.Translate(0,0,0.1);
}

}