using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	//衝突判定
	void OnCollisionEnter(Collision collision){
		//衝突したものが箱だったら
		if(collision.gameObject.tag == "Box"){
			//ダメージメッセージを送信する
			collision.gameObject.SendMessage ("ApplyDamage");
		}
		//弾丸自体の消滅
		Destroy(gameObject);
	}
}
