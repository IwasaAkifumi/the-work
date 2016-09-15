//ステージ1～3のボスのHP
#pragma strict

function Start () {
 this.transform.localScale.x=1;
}

function Update () {
this.transform.localScale.x=EnemyController.Enemylife/100.0;
}