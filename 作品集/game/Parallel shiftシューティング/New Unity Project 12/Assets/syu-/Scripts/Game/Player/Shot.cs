using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	public GameObject bullet;
	public Transform spawn;
	public float speed = 1000f;
	
	public Transform rifle; //修正箇所
	public float time = 0f; //経過時間
	public float interval = 0.3f;   //何秒おきに発砲するか
	
	//AudioSouceコンポーネントを取得
	public AudioSource sound;
	//Audioファイルを代入
	public AudioClip shotSound; //発砲音を代入
	
	void Start () {
		sound = this.gameObject.GetComponent<AudioSource>();    //Audio Sourceコンポーネントを代入
	}
	
	void Update () {
		time += Time.deltaTime; //経過時間を加算
		
		if(Input.GetButton("Fire1")){
			if(time >= interval){
				Shoot();    //発砲
				time = 0f;  //初期化
			}
		}
	}
	
	void Shoot () {
		//発射されるときに実行
		sound.PlayOneShot(shotSound);   //この関数は音声がなり終わらないうちにもう一度実行されると、重ねて音が再生される。
		
		GameObject obj = GameObject.Instantiate(bullet)as GameObject;
		obj.transform.position = spawn.position;
		obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed);    //修正箇所
		//銃の向きが元から反転しているため、併せてforwardも反転させる
	}
}