using UnityEngine;
using System.Collections;

public class GameRule3 : MonoBehaviour {
	private Ui		c93_Ui;
	private GameObject	player;
	private	Status	c13_status;
	
	private bool		isGameOver = false;	// ゲームオ―バーフラグ
	private bool		isGameClear = false;	// ゲームクリアフラグ
	
	public GameObject[]	isGameOver_obj;		// ゲームオーバー時にオンにするオブジェクトを格納する配列
	public GameObject[]	isGameClear_obj;		// ゲームクリア時にオンにするオブジェクトを格納する配列
	private GameObject	GameRoot;
	public Score Score;
	
	
	// ■■■■■■
	void Start(){
		c93_Ui		= GameObject.Find("GameRoot").GetComponent< Ui >();
		player		= GameObject.FindGameObjectWithTag("Player") as GameObject;
		c13_status	= player.GetComponent< Status >();
		Score	    = GetComponent< Score >();
	}
	
	// ■■■■■■
	void Update(){
		if(isGameOver){ return; }	// ゲームオーバーフラグがtrueの時、以降は処理しない
		if(isGameClear){ return; }	// ゲームクリアフラグがtrueの時、以降は処理しない
		
		player_clearCheck();			// ゲームクリア
		player_PositionOver();		// プレイヤーの現在の高さを確認し、規定値以下なら、ゲームオーバー
		player_DeadCheck();			// プレイヤーのHPを確認し、0なら、ゲームオーバー
		
		
	}
	
	// ゲームオーバー処理
	public void gameOver(){
		isGameOver = true;				// ゲームオーバーフラグをtrueに
		c93_Ui.enableText_GameOver();	// ゲームオーバーのテキストを表示させる。
		enabled_GameOverObject();		// ゲームオーバーに関わるオブジェクトを表示させる
	}
	public void gameClear(){
		isGameClear = true;				// ゲームクリアフラグをtrueに
		c93_Ui.enableText_GameClear();	// ゲームクリアのテキストを表示させる。
		enabled_GameClearObject();		// ゲームクリアに関わるオブジェクトを表示させる
	}
	
	// isGmaeOverの値を返す
	public bool getIsGameOver(){ return isGameOver; }
	public bool getIsGameClear(){ return isGameClear; }
	
	
	
	// プレイヤーの現在の高さを確認し、規定値以下なら、ゲームオーバー
	private void player_PositionOver(){
		if(player.transform.position.y <= -50.0f){
			gameOver();
			player.GetComponent< Player >().enabled = false;
		}
	}
	
	// プレイヤーのHPを確認し、0なら、ゲームオーバー
	private void player_DeadCheck(){
		if(c13_status.getHP() == 0){
			gameOver();
			player.GetComponent< Player >().enabled = false;
		}
	}
	// ゲームクリア
	private void player_clearCheck(){
		if(Score.score >= 5){
			gameClear();
			player.GetComponent< Player >().enabled = false;
		}
	}
	
	// ゲームオーバーに関わるオブジェクトを表示させる
	private void enabled_GameOverObject(){
		foreach(GameObject g in isGameOver_obj){
			g.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	// ゲームクリアに関わるオブジェクトを表示させる
	private void enabled_GameClearObject(){
		foreach(GameObject c in isGameClear_obj){
			c.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	
	// タイトルへ移動
	public void OnClickButton_TitleMove(){
		Application.LoadLevel("Menu");			// シーン移動
	}
	
	// リトライ
	public void OnClickButton_ReStart(){
		Application.LoadLevel("Stage2");			// シーン移動
	}
}