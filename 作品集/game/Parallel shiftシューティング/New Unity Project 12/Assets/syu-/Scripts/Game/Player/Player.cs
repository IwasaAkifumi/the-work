using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private	CharacterController charaCon;		// キャラクターコンポーネント用の変数
	private Vector3	move = Vector3.zero;		// キャラ移動量
	private float	speed = 1000.0f;
	public float shotspeed = 1500f;

	private const float	GRAVITY = 50.8f;			// 重力
	private float		jumpPower = 50.0f;		// 跳躍力
	private float		rotationSpeed = 180.0f;	// プレイヤーの回転速度

	private bool		moveType	= true;			// １人称視点動作：true , ３人称視点動作：false

	public GameObject targetEnemy = null;			// ターゲット格納用の変数.

	public	GameObject	prefab_hitEffect1;			// 攻撃時のヒットエフェクト.
	private Vector3		attackPoint;				// 攻撃位置.

	private Weapon	weapon;						// 武器
	public	GameObject	prefab_bom;					// 手榴弾
	private bool used_bom = false;			// 手榴弾の速射管理用.

	public	GameObject	prefab_dan;					// 弾
	private bool used_dan = false;			// 手の速射管理用.

	public	int			gun_num;					// 銃弾の残弾数.
	private const int	GUN_MAX_NUM = 30;			// 銃弾の最大弾数.

	private Sound	c92_sound;
	private int			gun_sound = 0;				// 銃撃の音No
	private int			bom_throw_sound = 1;		// 手榴弾を投げる音No.
	private int			wallDamage_sound = 3;		// 壁にぶつかる音No.

	private Ui		c93_Ui;

	private bool		isButton = false;			// ボタン上にカーソルがあるとtrue.

	private bool		isDamage = false;			// ダメージを受けているとtrue

	private Vector3 screenPoint;
	private Vector3 offset;

	private GameRule	c06_GameRule;

	public GameObject bullet;
	public Transform spawn;
	
	public Transform rifle; //修正箇所
	public float time = 0f; //経過時間
	public float interval = 0.3f;   //何秒おきに発砲するか
	
	void Start(){
		weapon = new Weapon();					// 武器のメモリを確保し、初期化。
		charaCon = GetComponent< CharacterController >();
		gun_num = GUN_MAX_NUM;						// 銃弾装填.
		c92_sound = GameObject.Find("Sound").GetComponent< Sound >();
		c93_Ui = GameObject.Find("GameRoot").GetComponent< Ui >();
		c06_GameRule	= GameObject.Find("GameRoot").GetComponent< GameRule >();

		//	c93_Ui.changeText_GunNum(gun_num);		// 下記のinitialize()に集約するため、削除
		c93_Ui.initialize(weapon.getType() , gun_num , used_bom , GetComponent< Status >());	// テキストの初期化


	}
	
	void Update () {
			setTargetEnemy ();						// ターゲット情報を取得
			if (Input.GetMouseButtonDown (0) && !isButton) {
				attack_weapon ();
			}		// 「左クリックを押す」かつ「ボタン上にカーソルがないなら」、武器で攻撃
			if (Input.GetMouseButtonDown (1)) {
				change_weapon ();
			}		// 右クリックを押すと、武器を変更

			if (moveType) {
				playerMove_1rdParson ();		// １人称視点動作
			}

	}

	// ■■■変数isButtonを書き換える■■■
	public void setIsButton(bool button){
		isButton = button;
	}

	// 武器で攻撃
	private void attack_weapon(){
			switch (weapon.getType ()) {
			case 0:
				attack03_dan ();
				break;		// 銃による攻撃
			case 1:
				attack02_bom ();
				break;		// 手榴弾による攻撃
			//case 2: attack01_gun(); break;		// 弾による攻撃
			}
	}
	// 銃による攻撃
	private void attack01_gun(){
		if(gun_num == 0){ return; }			// 残弾がないなら、以降は処理しない.
		
		if(targetEnemy != null){			// 照準にターゲットが入っているなら
			GameObject effect = Instantiate(prefab_hitEffect1 , attackPoint , Quaternion.identity) as GameObject;		// エフェクト発生
			Destroy(effect , 0.2f);
			Destroy(targetEnemy);
		}
		c92_sound.SendMessage("soundRings" , gun_sound);	// 銃撃の音を鳴らす.
		
		gun_num--;				// 弾数を減らす
		c93_Ui.changeText_GunNum(gun_num);			// 弾数の表示変更.
		if(gun_num == 0){ StartCoroutine("reChargeGun"); }	// 銃弾の再装填コルーチン開始
	}
	// 銃弾の再装填コルーチン
	IEnumerator reChargeGun(){
		yield return new WaitForSeconds(3.0f);		// 3秒、処理を待機.
		gun_num = GUN_MAX_NUM;						// 銃弾装填.
		c93_Ui.changeText_GunNum(gun_num);					// 弾数の表示変更.
	}
	
	// 手榴弾による攻撃
	private void attack02_bom(){
		if(!used_bom){
			Vector3 pos = transform.position + transform.TransformDirection(Vector3.forward);		// プレイヤー位置　+　プレイヤー正面にむけて１進んだ距離
			GameObject bom = Instantiate(prefab_bom , pos , Quaternion.identity) as GameObject;		// 手榴弾を作成
			
			Vector3 bom_speed = transform.TransformDirection(Vector3.forward)  * 50;		// 手榴弾の移動速度。『プレイヤー正面に向けての速度ベクトル』を５。
			bom_speed += Vector3.up * 15;			// 手榴弾の『高さ方向の速度』を加算
			bom.GetComponent<Rigidbody>().velocity = bom_speed;		// 手榴弾の速度を代入
			
			bom.GetComponent<Rigidbody>().angularVelocity = Vector3.forward * 150;	// 手榴弾を回転速度を代入.

			c92_sound.SendMessage("soundRings" , bom_throw_sound);		// 手榴弾を投げる音を鳴らす.

			
			used_bom = true;						// ボムを使用不可能にする.
			c93_Ui.changeText_Bom(used_bom);		// 手榴弾のテキスト変更
			StartCoroutine("reChargeBom");			// 手榴弾の速射管理コルーチンを開始(数秒後、ボムを再び使用可にする)
		}
	}
	
	// 弾の速射管理コルーチン
	IEnumerator reChargeBom(){
		yield return new WaitForSeconds(2.5f);		// 2.5秒、処理を待機.
		used_bom = false;
		c93_Ui.changeText_Bom(used_bom);		// 手榴弾のテキスト変更
	}
	void Shoot () {
		//発射されるときに実行
		
		GameObject obj = GameObject.Instantiate(bullet)as GameObject;
		obj.transform.position = spawn.position;
		obj.GetComponent<Rigidbody>().AddForce (rifle.forward * shotspeed);    //修正箇所
		//銃の向きが元から反転しているため、併せてforwardも反転させる
	}
	//弾による攻撃
	private void attack03_dan(){
		if(gun_num == 0){ return; }			// 残弾がないなら、以降は処理しない.
		if (!used_dan) {
			//time += Time.deltaTime; //経過時間を加算

			if (Input.GetButton ("Fire1")) {
			//	if (time >= interval) {
					Shoot ();    //発砲
					time = 0f;  //初期化
				c92_sound.SendMessage("soundRings" , gun_sound);	// 銃撃の音を鳴らす.
					c93_Ui.changeText_Bom (used_bom);		// 弾のテキスト変更
					StartCoroutine ("reChargeBom");			// 手榴弾の速射管理コルーチンを開始(数秒後、ボムを再び使用可にする)
				gun_num--;				// 弾数を減らす
				c93_Ui.changeText_GunNum(gun_num);			// 弾数の表示変更.
				if(gun_num == 0){ StartCoroutine("reChargeGun"); }	// 銃弾の再装填コルーチン開始
				//}
			}
		}
			
	}

	// 武器を変更
	public  void change_weapon(){
		weapon.changeWeapon();		// 武器タイプを変更
		c93_Ui.changeRawImage_Weapon(weapon.getType());	// 武器画像を変更.
		c93_Ui.changeText_enable(weapon.getType());		// 武器テキスト表示を切り替える.
	}
	// ターゲット情報を取得
	private void setTargetEnemy(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);	// クリックした位置から真っ直ぐ奥に行く光線.
		RaycastHit hitInfo;												// ヒット情報を格納する変数を作成
		
		if(Physics.Raycast(ray , out hitInfo , 1000)){			// カメラから距離10の光線を出し、もし何かに当たったら
			if(hitInfo.collider.gameObject.tag == "Enemy"){		// その当たったオブジェクトのタグ名が Enemy なら
				targetEnemy = hitInfo.collider.gameObject;		// 当たったオブジェクトを、参照。
				attackPoint = hitInfo.point;					// 光線が当たった位置を取得.
				return;											// ターゲットが見つかったので、処理を抜ける
			}
		}
		
		targetEnemy = null;		// Enemyが見つからないなら、null(空)にする
	}

	// 動作切り替え
	public void changeMoveType(bool type){
		moveType = type;
	}


	// １人称視点の移動
	private void playerMove_1rdParson(){
			// 移動量の取得
			float y = move.y;
			move = new Vector3 (0.0f, 0.0f, Input.GetAxis ("Vertical"));		// 上下のキー入力を取得し、移動量に代入.
			move = transform.TransformDirection (move);							// プレイヤー基準の移動方向へ修正する.
			move *= speed;				// 移動速度を乗算.
		
			// 重力／ジャンプ処理
			move.y += y;
			if (charaCon.isGrounded) {					// 地面に設置していたら
				if (Input.GetKeyDown (KeyCode.Space)) {	// ジャンプ処理.
					move.y = jumpPower;
				}
			}
			move.y -= GRAVITY * Time.deltaTime;	// 重力を代入.
		
			// プレイヤーの向き変更
			Vector3 playerDir = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, 0.0f);		// 左右のキー入力を取得し、移動方向に代入.
			playerDir = transform.TransformDirection (playerDir);					// プレイヤー基準の向きたい方向へ修正する.
			if (playerDir.magnitude > 0.1f) {
				Quaternion q = Quaternion.LookRotation (playerDir);			// 向きたい方角をQuaternionn型に直す .
				transform.rotation = Quaternion.RotateTowards (transform.rotation, q, rotationSpeed * Time.deltaTime);	// 向きを q に向けてじわ～っと変化させる.
			}
		
			// 移動処理
			charaCon.Move (move * Time.deltaTime);	// プレイヤー移動.
	}



	// ダメージを受けた時の無敵処理
	IEnumerator invincibleTime(float time){
		isDamage = true;
		yield return new WaitForSeconds(time);		// 処理を待機.
		isDamage = false;
	}

	// CharacterControllerに何かが当たっている時に呼び出される関数
	void OnControllerColliderHit(ControllerColliderHit hit){
		if(!isDamage){
			if(hit.gameObject.tag == "Enemy"){					// 衝突した相手のタグ名が"DamageArea"なら
				if(hit.gameObject.GetComponent< Status >()){		// 衝突した相手が C13_Status コンポーネントを持っているなら
					GetComponent< Status >().damage(hit.gameObject.GetComponent< Status >());	// HPを減らす
					c93_Ui.changeText_PlayerHP();					// プレイヤーHPの表示を更新。
					StartCoroutine("invincibleTime" , 0.5f);		// 0.5秒間、無敵状態にする。
					c93_Ui.StartCoroutine("monitorFlash");			// 画面をフラッシュさせる
					c92_sound.SendMessage("soundRings" , wallDamage_sound);		// 壁にぶつかった時の音を鳴らす.
				}
			}
		}
	}
	void OnMouseDown()
	{
			//カメラから見たオブジェクトの現在位置を画面位置座標に変換
			screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		
			//取得したscreenPointの値を変数に格納
			float x = Input.mousePosition.x;
			float y = Input.mousePosition.y;
		
			//オブジェクトの座標からマウス位置(つまりクリックした位置)を引いている。
			//これでオブジェクトの位置とマウスクリックの位置の差が取得できる。
			//ドラッグで移動したときのずれを補正するための計算だと考えれば分かりやすい
			offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (x, y, screenPoint.z));
	}
	
	void OnMouseDrag()
	{
	//	if (GetComponent<NetworkView>().isMine == true) {
			if (c06_GameRule.getIsGameOver ()) {
				return;
			}			// ゲームオーバーなら、以降は処理しない。
			if (c06_GameRule.getIsGameClear ()) {
				return;
			}			// ゲームクリアなら、以降は処理しない。
			//ドラッグ時のマウス位置を変数に格納
			float x = Input.mousePosition.x;
			float y = Input.mousePosition.y;
		
			Debug.Log (x.ToString () + " - " + y.ToString ());
		
			//ドラッグ時のマウス位置をシーン上の3D空間の座標に変換する
			Vector3 currentScreenPoint = new Vector3 (x, y, screenPoint.z);
		
			//上記にクリックした場所の差を足すことによって、オブジェクトを移動する座標位置を求める
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint) + offset;
		
			//オブジェクトの位置を変更する
			transform.position = currentPosition;
	//	}
	}

}
