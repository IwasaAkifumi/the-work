//メニュー画面のステージ画像切り替え
#pragma strict
var STAGE1 : Texture;
var STAGE2 : Texture;
var STAGE3 : Texture;
var STAGE4 : Texture;
var STAGE5 : Texture;
var STAGE6 : Texture;

function Update () {
if(Menu.i==0){
  renderer.material.mainTexture = STAGE1;
  }else if(Menu.i==1){
  renderer.material.mainTexture = STAGE2;
  }else if(Menu.i==2){
   renderer.material.mainTexture = STAGE3;
  }else if(Menu.i==3){
   renderer.material.mainTexture = STAGE4;
  }else if(Menu.i==4){
  renderer.material.mainTexture = STAGE5;
  }else if(Menu.i==5){
  renderer.material.mainTexture = STAGE6;
 }
 }