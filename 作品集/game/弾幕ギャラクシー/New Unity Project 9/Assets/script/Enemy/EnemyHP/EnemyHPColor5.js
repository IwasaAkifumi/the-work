//ステージ5のボスのHPカラー
#pragma strict
var EnemyHP : Texture;
var EnemyHP2 : Texture;
var EnemyHP3 : Texture;

function Start () {
renderer.material.mainTexture = EnemyHP;
}

function Update () {
if(EnemyController5.Enemylife > 50.0)
 renderer.material.mainTexture = EnemyHP;
 if(EnemyController5.Enemylife < 50.0 && EnemyController.Enemylife > 25.0)
 renderer.material.mainTexture = EnemyHP2;
  if(EnemyController5.Enemylife < 25.0 && EnemyController.Enemylife > 0.0)
 renderer.material.mainTexture = EnemyHP3;
 }