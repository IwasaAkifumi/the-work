//スクリプトは以下から

using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	
	public float score = 10;    //敵を倒した際にもらえるスコア
	public GameObject explosion;    //爆発エフェクト
	public ScoreSystem Score;   //スコアシステムを使用する
	public Score S_Score;
	private GameObject	GameRoot;
	public float      killTimer = 9999f;//ダイマー
	
	public float life = 30; //敵の体力
	
	void Start () {
		Score = GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>(); //スコアシステムを代入
		S_Score	= GetComponent< Score >();
	}
	
	void Update () {

	}
	
	//Damage関数ここを修正していく
	public void Damage ( float damage ) {
		life -= damage; //体力から差し引く
		if(life <= 0){
			GetComponent<Rigidbody>().AddForce (Vector3.up * 150.0f, ForceMode.Impulse);
			//体力が0以下になった時
			Dead(); //死亡処理

		}
	}
	
	//死亡処理
	public void Dead () {
		GameObject.Instantiate(explosion, transform.position, Quaternion.identity); //爆発パーティクルを生成
		Score.AddScore(score);  //スコアを加算
		//S_Score.addScore ();  //討伐数
		Destroy(this.gameObject);   //自身を削除
		GameObject.Find("GameRoot").GetComponent< Score >().addScore();	// スコア＋１
	}
}