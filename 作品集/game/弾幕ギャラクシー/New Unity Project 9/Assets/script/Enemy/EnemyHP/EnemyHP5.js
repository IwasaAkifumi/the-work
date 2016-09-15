//ステージ5のボスのHP
#pragma strict

function Start () {
 this.transform.localScale.x=1;
}

function Update () {
 this.transform.localScale.x=EnemyController5.Enemylife/100.0;
}