//安藤.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HP : MonoBehaviour {
	
	Slider slider;
	void Start () {
		// スライダーを取得する
		slider = GameObject.Find("HP01").GetComponent<Slider>();
		
	}
	
	static public int skill = 10;
	void Update () {
		// HP上昇
		if(skill < 0)
			skill =0;
		if(skill > 10)
			skill =10;
		// HPゲージに値を設定
		slider.value = skill;
	}

}
