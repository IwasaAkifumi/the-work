//Player1のボスのHP
#pragma strict

function Start () {
 this.transform.localScale.x=1;
}

function Update () {
 this.transform.localScale.x=VSEnemyController.Enemylife/100.0;
 }