using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {
	private Player player;
	
	void Start () {
		player = GameObject.FindWithTag("Player").GetComponent< Player >();
	}
	
/*	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)){	// タブキーが押されたら.
			changeCameraMode();
		}
	}*/
	
	// カメラ切り替え
	public void changeSight(bool type){
		if(type){	changeCameraMode_1stPerson();	// １人称カメラへの切り替え
		}else	{	changeCameraMode_3stPerson();	// ３人称カメラへの切り替え
		}
	}
	
	// １人称カメラへの切り替え
	private void changeCameraMode_1stPerson(){
		if(transform.parent == null){							// もし親オブジェクトがいなければ
			transform.parent			= player.transform;		// 自身の親オブジェクトに、playerオブジェクトを指定.
			transform.localPosition		= Vector3.zero;				// カメラの相対位置を零に.
			transform.localEulerAngles	= Vector3.zero; 			// カメラの相対角度を零に.(プレイヤーが向いている方向に)
		}
	}
	
	// ３人称カメラへの切り替え
	private void changeCameraMode_3stPerson(){
		if(transform.parent != null){					// もし親オブジェクトがいるなら
			transform.parent	= null;						// 親子関係を解除
			transform.position	= new Vector3(0,4,-10);		// カメラ位置を基本視点に変更。
			transform.localEulerAngles	= Vector3.zero;		// カメラ角度を基本視点に変更
		}
	}
}