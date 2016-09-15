//ステージ6のボスのHP
#pragma strict

function Start () {
 this.transform.localScale.x=1;
}

function Update () {
 this.transform.localScale.x=EnemyController6.Enemylife/100.0;
}