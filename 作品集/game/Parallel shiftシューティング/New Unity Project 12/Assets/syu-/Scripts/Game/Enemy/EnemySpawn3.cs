using UnityEngine;
using System.Collections;

public class EnemySpawn3 : MonoBehaviour {
	public GameObject enemy;    //敵オブジェクト
	public Transform ground;    //地面オブジェクト
	public float count = 5;     //一度に何体のオブジェクトをスポーンさせるか
	public float interval = 5;  //何秒おきに敵を発生させるか
	private float timer;        //経過時間

	private GameRule	c06_GameRule;

	// Use this for initialization
	void Start () {
		c06_GameRule	= GameObject.Find("GameRoot").GetComponent< GameRule >();
		Spawn();    //初期スポーン
	}
	
	// Update is called once per frame
	void Update () {
		if(c06_GameRule.getIsGameOver()){ return; }			// ゲームオーバーなら、以降は処理しない。
		if(c06_GameRule.getIsGameClear()){ return; }			// ゲームクリアなら、以降は処理しない。
		timer += Time.deltaTime;    //経過時間加算
		if(timer >= interval){
			Spawn();    //スポーン実行
			timer = 0;  //初期化
		}
	}
	
	void Spawn () {
		for(int i = 0; i < count; i++) {
			float x = Random.Range(-200f,200f);
			float z = Random.Range(-200f,200f);
			Vector3 pos = new Vector3(x, 5, z) + ground.position;
			GameObject.Instantiate(enemy, pos, Quaternion.identity);
		}
	}
}