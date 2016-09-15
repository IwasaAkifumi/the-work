using UnityEngine;
using System.Collections;

public class Bom : MonoBehaviour {

	private Sound	c92_sound;
	private int			bom_explosion_sound = 2;		// 手榴弾の爆発音No.

	public float bomattack = 70;   //攻撃力

	public GameObject prefab_HitEffect2;
	void Start () {
		StartCoroutine("bom");		// コルーチン開始
		c92_sound = GameObject.Find("Sound").GetComponent< Sound >();
	}

	
	IEnumerator bom(){
		yield return new WaitForSeconds(2.5f);		// 2.5秒、処理を待機.
		GameObject effect = Instantiate(prefab_HitEffect2 , transform.position , Quaternion.identity) as GameObject;	// ボムエフェクト発生
		Destroy(effect , 1.0f);		// ボムエフェクトを、１秒後に消滅させる

		c92_sound.SendMessage("soundRings" , bom_explosion_sound);		// 手榴弾を爆発音を鳴らす.
		bomAttack();				// ボムによる攻撃処理
		
		Destroy(gameObject);		// 自分自身を消滅させる。
	}
	
	// ボムによる攻撃処理
	private void bomAttack(){
		Collider[] targets = Physics.OverlapSphere(transform.position , 1000f);	// 自分自身を中心に、半径0.7以内にいるColliderを探し、配列に格納.

		foreach(Collider obj in targets){		// targets配列を順番に処理 (その時に仮名をobjとする)
			if(obj.tag == "Enemy"){				// タグ名がEnemyなら
				obj.SendMessage("Damage",bomattack);
			}
		}
	}
}
