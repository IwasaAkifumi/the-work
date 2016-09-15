using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Scorekeeper))]  //同コンポーネント内に含ませる

public class Referee : MonoBehaviour {

	public float switchInterval;//色切り替え間隔
	public int   rewardPoint;   //正しい標的を撃った時の加点
	public int   penaltyPoint;  //間違った標的を撃った時の減点

	private Scorekeeper scorekeeper; //Scorekeeperへの参照
	private bool       targetIsRed; //赤が標的の時true
	private float      switchTimer; //色の切り替えタイマー

	public GUISkin skin;

	// Use this for initialization
	void Start () {
		//scorekeeperへの参照を確保する
		scorekeeper = (Scorekeeper)GetComponent (typeof(Scorekeeper));
		//赤からスタート
		targetIsRed =true;
		//タイマーセット
		switchTimer = switchInterval;
	
	}
	
	// 標的の切り替えとタイマーのセット
	void Update () {
		switchTimer -= Time.deltaTime;
		if(switchTimer < 0.0f){
			//色の反転
			targetIsRed = !targetIsRed;
			//タイマーの再セット
			switchTimer = switchInterval;
	}
}

	//現在の標的を返す
	private string GetTargetColorName(){
		return targetIsRed ? "Red" : "Blue";
	}

	//標的破壊のメッセージを受け取った時の処理
	void OnDestroyTarget(string boxColorName){
		if(boxColorName == GetTargetColorName()){
		//加点
		scorekeeper.score += rewardPoint;
		}else{
		//減点
		scorekeeper.score -= penaltyPoint;
		}
	}

	//現在のターゲットを描画
	void OnGUI(){
		//残り1.5秒を切ると描画しない
		if(switchTimer < 1.5) return;

		//描画用文字列
		string message = "Shoot " + GetTargetColorName() +"Boxes";

		//位置情報を決める
		int sw    = Screen.width;
		int sh    = Screen.height;
		Rect rect = new Rect(0,sh/4,sw,sh/2);
		GUI.skin  = skin;

		//文字色のセット
		GUI.color = targetIsRed ? Color.red : Color.blue;

		//ラベル描画
		GUI.Label(rect,message,"Message");
	}
	void TimeUp(){
		enabled=false;
	}
	void StartGame(){
		enabled=true;
	}
}




























