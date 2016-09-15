//ステージ4のボスのHP
#pragma strict

function Start () {
 this.transform.localScale.x=1;
}

function Update () {
 this.transform.localScale.x=EnemyController4.Enemylife/100.0;
}