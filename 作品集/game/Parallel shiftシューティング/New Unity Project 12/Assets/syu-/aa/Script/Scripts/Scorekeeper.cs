using UnityEngine;
using System.Collections;

public class Scorekeeper : MonoBehaviour {

	[HideInInspector]
	public int score;
	public GUISkin skin;

	void OnGUI(){
		//表示する文字
		string scoreText = "SCORE: " + score.ToString();

		//描画領域の設定
		int sw    = Screen.width;
		int sh    = Screen.height;
		Rect rect = new Rect(0,0,sw/2,sh/4);
		GUI.skin = skin;

		//ラベルの描画
		GUI.Label(rect,scoreText,"Score");
	}
	
}
