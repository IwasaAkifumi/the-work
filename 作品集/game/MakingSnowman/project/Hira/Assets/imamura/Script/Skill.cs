//今村.
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class Skill: MonoBehaviour {
	
	Slider slider;
	static public int a;
	static public int b;
	static public int c;
	static public int d;
	static public int skill = 0;
	void Start () {
		// スライダーを取得する
		slider = GameObject.Find("Skill").GetComponent<Slider>();
		a = b = c = d = 0;
		skill = 0;
	}
	

	void Update () {
		// HP上昇

		if(skill < 0)
			skill =0;
		if(skill > 2500)
			skill =2500;
		// HPゲージに値を設定
		slider.value = skill;
	}
}
