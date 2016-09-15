//Player1のボスのHPカラー
#pragma strict
var EnemyHP : Texture;
var EnemyHP2 : Texture;
var EnemyHP3 : Texture;

function Start () {
renderer.material.mainTexture = EnemyHP;
}

function Update () {
if(VSEnemyController.Enemylife > 50)
 renderer.material.mainTexture = EnemyHP;
 if(VSEnemyController.Enemylife < 50 && EnemyController.Enemylife > 25)
 renderer.material.mainTexture = EnemyHP2;
  if(VSEnemyController.Enemylife < 25 && EnemyController.Enemylife > 0)
 renderer.material.mainTexture = EnemyHP3;
 }
