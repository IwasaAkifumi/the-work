﻿//ステージ6のボスのHPカラー
#pragma strict
var EnemyHP : Texture;
var EnemyHP2 : Texture;
var EnemyHP3 : Texture;

function Start () {
renderer.material.mainTexture = EnemyHP;
}

function Update () {
if(EnemyController6.Enemylife > 50)
 renderer.material.mainTexture = EnemyHP;
 if(EnemyController6.Enemylife < 50 && EnemyController.Enemylife > 25)
 renderer.material.mainTexture = EnemyHP2;
  if(EnemyController6.Enemylife < 25 && EnemyController.Enemylife > 0)
 renderer.material.mainTexture = EnemyHP3;
 }