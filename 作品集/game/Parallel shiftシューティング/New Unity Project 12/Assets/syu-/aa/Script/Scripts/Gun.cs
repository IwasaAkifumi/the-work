using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float      initialVelocity; //弾丸の初速
	public GameObject bulletPrefab;    //弾丸のプレハブ


	
	// Update is called once per frame
	void Update () {
		//キー入力の検出
		if(Input.GetMouseButtonDown (0)){

			//弾丸のインスタンス化
			GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position,transform.rotation);

			//クリックした座標の取得
			Vector3 screenPoint = Input.mousePosition;
			screenPoint.z = 10f;

			//ワールド座標系に変換
			Vector3 worldPoint = GetComponent<Camera>().ScreenToWorldPoint (screenPoint);

			//カメラ位置からクリックした点へ向かうベクトルに変換
			Vector3 direction = Vector3.Normalize(worldPoint - transform.position);
			bullet.GetComponent<Rigidbody>().velocity = direction * initialVelocity;
		}

	
	}
	void TimeUp(){
		enabled=false;
	}
}
