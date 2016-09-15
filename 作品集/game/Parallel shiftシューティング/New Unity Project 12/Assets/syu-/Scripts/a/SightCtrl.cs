using UnityEngine;
using System.Collections;

public class SightCtrl : MonoBehaviour {
	private Player player;
	private CameraCtrl mainCamera , subCamera;
	private bool cameraSight = true;		// １人称視点：true  , ３人称視点：flase
	
	// 
	void Start () {
		player		= GameObject.Find("Player").GetComponent< Player >();
		mainCamera	= GameObject.Find("Main Camera").GetComponent< CameraCtrl >();
		subCamera	= GameObject.Find("Sub Camera").GetComponent< CameraCtrl >();
		
		changeCameraSight();	// 視点切り替え命令
	}
	
	// 
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)){
			cameraSight	= !cameraSight;
			changeCameraSight();	// 視点切り替え命令
		}
	}
	
	// 視点切り替え命令
	private void changeCameraSight(){
		player.changeMoveType(cameraSight);		// プレイヤーの動作モードタイプ変更
		mainCamera.changeSight(cameraSight);	// メインカメラの視点切り替え
		subCamera.changeSight(!cameraSight);	// サブカメラの視点切り替え
	}
}