//安藤.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHP : MonoBehaviour {

	
	Slider slider;
	void Start () {
		// スライダーを取得する
		slider = GameObject.Find("Boss_HP").GetComponent<Slider>();

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
