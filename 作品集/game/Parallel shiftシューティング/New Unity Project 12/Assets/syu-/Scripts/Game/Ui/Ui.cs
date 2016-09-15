using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ui : MonoBehaviour {
	public	Text[] text_gun_num;

	public	RawImage	rawImage_WeaponType;	// 武器画像を表示させるRawImageオブジェクト格納用
	public	Texture[]	texture_Weapon;			// 武器画像
	public	Text		text_bom;				// 手榴弾の表示用

	public	Text		text_playerHP;			// プレイヤーのHP表示用
	private Status	c13_status;				// プレイヤーのステータス参照用.

	public	Image		panel_flashMonitor;		// 画面フラッシュ用
	public	Text		text_GameOver;			// ゲームオーバー用
	public	Text		text_GameClear;			// ゲームクリア用
	public	Text		text_Score;				// スコア用

	
	// 斬弾数を変更
	public void changeText_GunNum(int num){
		foreach(Text t in text_gun_num){		// text_gun_num配列の中身を順に操作
			if(t != null){						// 中身がnullでないなら
				t.text = "残弾：" + num;			// テキストを変更.
			}
		}
	}
	// 武器画像を変更
	public void changeRawImage_Weapon(int weaponNo){
		if(weaponNo > texture_Weapon.Length-1){		// 渡された数字が不正なら
			rawImage_WeaponType.texture = null;		// 画像なし
			return;									// 処理を抜ける.
		}		
		
		rawImage_WeaponType.texture = texture_Weapon[weaponNo];		// 画像を変更
	}
	// 手榴弾のテキスト変更
	public void changeText_Bom(bool used){
		if(text_bom != null){								// 中身がnull(空)でないなら
			text_bom.text = used ? "装填中" :  "使用可";		// used が true なら、"装填中"を代入。falseなら"使用可"を代入する
		}
	}
	
	// 武器タイプによるテキストの表示オン／オフ
	public void changeText_enable(int type){
		switch(type){
		case 0:		// 武器タイプが銃の場合
			foreach(Text t in text_gun_num){ t.enabled = true; }
			text_bom.enabled = false;
			break;
		case 1:		// 武器タイプが手榴弾の場合
			foreach(Text t in text_gun_num){ t.enabled = false; }
			text_bom.enabled = true;
			break;
		}
	}
	
	// テキスト初期化用
	public void initialize(int type ,int num , bool used , Status status){
		changeText_enable(type);	// 武器タイプによるテキストの表示オン／オフ
		
		changeText_GunNum(num);		// 残弾数を変更
		changeText_Bom(used);		// 手榴弾のテキスト変更

		c13_status = status;
		changeText_PlayerHP();		// プレイヤーHPの変更
		changeText_Score(0);		// スコアのテキスト更新
	}
	// プレイヤーHPのテキスト変更
	public void changeText_PlayerHP(){
		if(text_playerHP != null){					// 中身がnull(空)でないなら
			text_playerHP.text = "体力：" + c13_status.getHP();	// テキスト変更
		}
	}
	// 画面をフラッシュさせる
	IEnumerator monitorFlash(){
		panel_flashMonitor.enabled = true;
		yield return new WaitForSeconds(0.1f);		// 処理を待機.
		panel_flashMonitor.enabled = false;
	}
	public void enableText_GameClear(){
		text_GameClear.enabled = true;
	}
	// ゲームオーバーのテキストを表示させる
	public void enableText_GameOver(){
		text_GameOver.enabled = true;
	}

	// ■■■スコアのテキスト更新■■■
	public void changeText_Score(int value){
		if(text_Score != null){
			text_Score.text = "討伐数： " + value + " 体";
		}
	}
}