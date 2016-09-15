//Player2のボスのHP
#pragma strict

function Start () {
 this.transform.localScale.x=1;
}
function Update () {
 this.transform.localScale.x=VSEnemyController2.Enemylife2/100.0;
 }

