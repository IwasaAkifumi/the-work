//PlayerのHPの色
#pragma strict
var HP : Texture;
var HP2 : Texture;
var HP3 : Texture;

function Update () {
  switch(PlayerController.life){//現在選択中の状態によって処理を分岐
case 5:
 renderer.material.mainTexture = HP;
	break;
case 2:
 renderer.material.mainTexture = HP2;
	break;
case 1:
 renderer.material.mainTexture = HP3;
	break;
	}

}