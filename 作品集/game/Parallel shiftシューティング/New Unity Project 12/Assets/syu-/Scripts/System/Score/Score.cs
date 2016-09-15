using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int score = 0;
	private Ui c93_Ui;
	
	// ■■■■■■
	void Start(){
		c93_Ui = GetComponent< Ui >();	// 同じオブジェクトが持っている《C93_Ui》コンポーネントを取得
	}
	
	// ■■■スコア＋１■■■
	public void addScore(){
		score++;							// スコア +1
		c93_Ui.changeText_Score(score);		// スコアテキスト更新
	}
}