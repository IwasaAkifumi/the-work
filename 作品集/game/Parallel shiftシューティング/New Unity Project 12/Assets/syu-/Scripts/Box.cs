using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	//プレハブを受け取る変数
	public GameObject explosionPrefab; 
	private bool       damaged;  //ダメージフラグ
	private float      killTimer;//ダイマー
	public string colorName;

	void Awake(){
		damaged = false;
	}

	//送ったメッセージと同じ名前の関数を定義する
	void ApplyDamage(){

		//命中したら爆発までのカウントをスタート
		if(!damaged){
			damaged  = true;
			killTimer = 0.4f;

			//上向きの力を加える
			GetComponent<Rigidbody>().AddForce (Vector3.up * 15.0f, ForceMode.Impulse);
		}
	}

	void Update(){
		if(!damaged) return;
		killTimer -= Time.deltaTime;
		if(killTimer < 0.0f){
			//破壊をGameControllerに通知
			GameObject gameController = GameObject.FindGameObjectWithTag ("GameController");
			gameController.SendMessage("OnDestroyTarget",colorName);

		Instantiate (explosionPrefab, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
}
