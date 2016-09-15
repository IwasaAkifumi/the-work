using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSystem : MonoBehaviour {

	public GameObject mainCamera; //カメラの定義

	private const int TileLineNum = 6;
	private const int TileColNum = 6;
	private const float TileWidth = 50;
	private const float TileHeight = 50f;
	private const float FirstTilePosX = -420f;
	private const float FirstTilePosY = 31;
	private int[,] tileTable = new int[TileLineNum,TileColNum];//消去するための情報を保持しておくフィールド
	private bool[,] deleteTable = new bool[TileLineNum, TileColNum];

	public bool isPlaying = false;
	
	public Sprite[] Tiles;
	public GameObject TileObj;
	public GameObject holdObj;//保持したGameObject
	public float holdPositionX;//保持したときのGameObjectのX座標
	public float holdPositionY;//保持したときのGameObjectのy座標
	private float z = 10.0f;
	private GameObject[,] tileSet;

	private const int Line_TileLineNum = 6;
	private const int Line_TileColNum = 6;
	private const float Line_TileWidth = 50f;
	private const float Line_TileHeight = 50f;
	private const float Line_FirstTilePosX = -420f;
	private const float Line_FirstTilePosY = 30;
	public GameObject Line_holdObj;
	public float Line_holdPositionX;
	public float Line_holdPositionY;
	//private float Line_z = 0f;
	private GameObject[,] tilelineSet;

	public ballScript ballScript;

	public GameObject chara;
	public GameObject chara2;
	public GameObject chara3;
	public GameObject Enemy;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public int characterAttack; //選択したキャラクターのステータス攻撃
	public int characterAttack_S; //選択したキャラクターのステータス得意攻撃
	public int characterBlock; //選択したキャラクターのステータス防御
	public int characterHp; //選択したキャラクターのステータスHP
	public int EnemysAttack; //選択したキャラクターの敵ステータス攻撃
	public int EnemysBlock; //選択したキャラクターの敵ステータス防御
	public int EnemysHp; //選択したキャラクターの敵ステータスHP
	public int EnemysCount; //選択したキャラクターの敵攻撃カウント
	public string playerType; //選択したキャラクターの属性
	public string enemyType; //選択したキャラクターの属性
	public int damegeTxst = 0; //選択したキャラクターダメージテキスト


	private Status status;
	private Status Enemystatus;
	public EnemyCount EnemyCount;
	private GameObject eCount;

	public GameObject scoreGUI;
	private int point = 100;
	
	public Gauge Gauge;
	public P_Gauge P_Gauge;


	public GameObject damageMotion;
	public GameObject P_damageMotion;
	public GameObject Motion;
	public GameObject P_Motion;

	//ドロップ効果
	public int Spdrop;

	public int stage;

	// 再生したいEffectのプレハブを指定する
	public GameObject Effect01 = null;
	
	public AudioClip charaDamage;
	
	// Use this for initialization
	void Start () {
		if (stage == 1) CharacterSet ();
		if (stage == 2) CharacterSet2 ();
		if (stage == 3) CharacterSet3 ();
		EnemysCount = 3;
		EnemyCount.score = 3;
		/*SetTileSet();
		SetTileLineSet();
		InitalizeTile();*/
		GameObject chara = GameObject.Find("Chara");
		GameObject chara2 = GameObject.Find("Chara2");
		GameObject chara3 = GameObject.Find("Chara3");
		GameObject Enemy = GameObject.Find("Enemy");
		GameObject Enemy2 = GameObject.Find("Enemy2");
		GameObject Enemy3 = GameObject.Find("Enemy3");
		eCount = GameObject.Find ("EnemyCount");

	}
	// Update is called once per frame
	void Update () {
		Gauge.SetNow(EnemysHp);
		P_Gauge.P_SetNow(characterHp);
		/*if (isPlaying) {
			if (Input.GetMouseButtonDown (0)) {//ボタンを押下した瞬間
				LeftClick ();
			}
			if (Input.GetMouseButton (0)) {//ボタンを押し続けてる間
				LeftDrag ();
			}
			if (Input.GetMouseButtonUp (0)) {//ボタンが上がった瞬間
				LeftUp ();
			}
		}*/
	}
	//キャラクター表示
	private void CharacterSet(){
		switch (PlayerPrefs.GetInt ("name")) {
		case 1:
			//自分ステータス
			chara.SetActive (true);//自分表示
			P_damageMotion = chara;  //自分のダメージモーション
			P_Motion = chara;  //自分のモーション
			status = chara.GetComponent<Status>();//自分の初期ステータス設定
			characterAttack = status.PostAttack();//自分の攻撃力設定
			characterAttack_S = characterAttack*2;
			characterHp = status.PostHp();//自分のダメージ処理に使うHP設定
			P_Gauge.P_SetMax(characterHp);//自分の満タン時のHP設定
			playerType = "red";
			//敵ステータス
			Enemy3.SetActive (true); //緑敵の表示
			damageMotion = Enemy3;//敵のダメージモーション
			Motion = Enemy3;  //敵のモーション
			Enemystatus = Enemy3.GetComponent<Status>();//自分の初期ステータス設定
			EnemysAttack = Enemystatus.PostAttack();//敵の攻撃力設定
			EnemysHp = Enemystatus.PostHp();//敵のダメージ処理に使うHP設定
			Gauge.SetMax(EnemysHp);//敵の満タン時のHP設定
			enemyType = "green";

			break;
		case 2:
			chara2.SetActive (true);
			P_damageMotion = chara2;
			P_Motion = chara2;  //自分のモーション
			status = chara2.GetComponent<Status>();
			characterAttack = status.PostAttack();
			characterAttack_S = characterAttack*2;
			characterHp = status.PostHp();
			P_Gauge.P_SetMax(characterHp);
			playerType = "blue";

			Enemy.SetActive (true);//赤敵
			damageMotion = Enemy;
			Motion = Enemy;  //敵のモーション
			Enemystatus = Enemy.GetComponent<Status>();//自分の初期ステータス設定
			EnemysAttack = Enemystatus.PostAttack();//敵の攻撃力設定
			EnemysHp = Enemystatus.PostHp();//敵のダメージ処理に使うHP設定
			Gauge.SetMax(EnemysHp);//敵の満タン時のHP設定
			enemyType = "red";

			break;
		case 3:
			chara3.SetActive (true);//青敵
			P_damageMotion = chara3;
			P_Motion = chara3;  //自分のモーション
			status = chara3.GetComponent<Status>();
			characterAttack = status.PostAttack();
			characterAttack_S = characterAttack*2;
			characterHp = status.PostHp();
			P_Gauge.P_SetMax(characterHp);
			playerType = "green";

			Enemy2.SetActive (true);
			damageMotion = Enemy2;
			Motion = Enemy2;  //敵のモーション
			Enemystatus = Enemy2.GetComponent<Status>();//自分の初期ステータス設定
			EnemysAttack = Enemystatus.PostAttack();//敵の攻撃力設定
			EnemysHp = Enemystatus.PostHp();//敵のダメージ処理に使うHP設定
			Gauge.SetMax(EnemysHp);//敵の満タン時のHP設定
			enemyType = "blue";
			break;
		default:
			break;
		}
		iTween.ScaleTo (P_Motion, iTween.Hash ("y", 55, "time", 2.0f, "easetype", "easeInCubic","LoopType","pingPong"));
		iTween.ScaleFrom (Motion, iTween.Hash ("y", 55, "time", 2.0f,"LoopType","pingPong","Delay",0.2));
	}
	private void CharacterSet2(){
		switch (PlayerPrefs.GetInt ("name")) {
		case 1:
			//自分ステータス
			chara.SetActive (true);//自分表示
			P_damageMotion = chara;  //自分のダメージモーション
			P_Motion = chara;  //自分のモーション
			status = chara.GetComponent<Status>();//自分の初期ステータス設定
			characterAttack = status.PostAttack();//自分の攻撃力設定
			characterAttack_S = characterAttack*2;
			characterHp = status.PostHp();//自分のダメージ処理に使うHP設定
			P_Gauge.P_SetMax(characterHp);//自分の満タン時のHP設定
			playerType = "red";
			
			Enemy.SetActive (true);//赤敵
			damageMotion = Enemy;
			Motion = Enemy;  //敵のモーション
			Enemystatus = Enemy.GetComponent<Status>();//自分の初期ステータス設定
			EnemysAttack = Enemystatus.PostAttack();//敵の攻撃力設定
			EnemysHp = Enemystatus.PostHp();//敵のダメージ処理に使うHP設定
			Gauge.SetMax(EnemysHp);//敵の満タン時のHP設定
			enemyType = "red";
			//敵ステータス
			break;
		case 2:
			chara2.SetActive (true);
			P_damageMotion = chara2;
			P_Motion = chara2;  //自分のモーション
			status = chara2.GetComponent<Status>();
			characterAttack = status.PostAttack();
			characterAttack_S = characterAttack*2;
			characterHp = status.PostHp();
			P_Gauge.P_SetMax(characterHp);
			playerType = "blue";
			
			Enemy2.SetActive (true);//青敵
			damageMotion = Enemy2;
			Motion = Enemy2;  //敵のモーション
			Enemystatus = Enemy2.GetComponent<Status>();//自分の初期ステータス設定
			EnemysAttack = Enemystatus.PostAttack();//敵の攻撃力設定
			EnemysHp = Enemystatus.PostHp();//敵のダメージ処理に使うHP設定
			Gauge.SetMax(EnemysHp);//敵の満タン時のHP設定
			enemyType = "blue";
			break;
		case 3:
			chara3.SetActive (true);
			P_damageMotion = chara3;
			P_Motion = chara3;  //自分のモーション
			status = chara3.GetComponent<Status>();
			characterAttack = status.PostAttack();
			characterAttack_S = characterAttack*2;
			characterHp = status.PostHp();
			P_Gauge.P_SetMax(characterHp);
			playerType = "green";
			
			Enemy3.SetActive (true); //緑敵の表示
			damageMotion = Enemy3;//敵のダメージモーション
			Motion = Enemy3;  //敵のモーション
			Enemystatus = Enemy3.GetComponent<Status>();//自分の初期ステータス設定
			EnemysAttack = Enemystatus.PostAttack();//敵の攻撃力設定
			EnemysHp = Enemystatus.PostHp();//敵のダメージ処理に使うHP設定
			Gauge.SetMax(EnemysHp);//敵の満タン時のHP設定
			enemyType = "green";
			break;
		default:
			break;
		}
		iTween.ScaleTo (P_Motion, iTween.Hash ("y", 55, "time", 2.0f, "easetype", "easeInCubic","LoopType","pingPong"));
		iTween.ScaleFrom (Motion, iTween.Hash ("y", 55, "time", 2.0f,"LoopType","pingPong","Delay",0.2));
	}
	private void CharacterSet3(){
		switch (PlayerPrefs.GetInt ("name")) {
		case 1:
			//自分ステータス
			chara.SetActive (true);//自分表示
			P_damageMotion = chara;  //自分のダメージモーション
			P_Motion = chara;  //自分のモーション
			status = chara.GetComponent<Status>();//自分の初期ステータス設定
			characterAttack = status.PostAttack();//自分の攻撃力設定
			characterAttack_S = characterAttack*2;
			characterHp = status.PostHp();//自分のダメージ処理に使うHP設定
			P_Gauge.P_SetMax(characterHp);//自分の満タン時のHP設定
			playerType = "red";
			
			Enemy2.SetActive (true);//青敵
			damageMotion = Enemy2;
			Motion = Enemy2;  //敵のモーション
			Enemystatus = Enemy2.GetComponent<Status>();//自分の初期ステータス設定
			EnemysAttack = Enemystatus.PostAttack();//敵の攻撃力設定
			EnemysHp = Enemystatus.PostHp();//敵のダメージ処理に使うHP設定
			Gauge.SetMax(EnemysHp);//敵の満タン時のHP設定
			enemyType = "blue";
			break;
		case 2:
			chara2.SetActive (true);
			P_damageMotion = chara2;
			P_Motion = chara2;  //自分のモーション
			status = chara2.GetComponent<Status>();
			characterAttack = status.PostAttack();
			characterAttack_S = characterAttack*2;
			characterHp = status.PostHp();
			P_Gauge.P_SetMax(characterHp);
			playerType = "blue";
			
			
			Enemy3.SetActive (true); //緑敵の表示
			damageMotion = Enemy3;//敵のダメージモーション
			Motion = Enemy3;  //敵のモーション
			Enemystatus = Enemy3.GetComponent<Status>();//自分の初期ステータス設定
			EnemysAttack = Enemystatus.PostAttack();//敵の攻撃力設定
			EnemysHp = Enemystatus.PostHp();//敵のダメージ処理に使うHP設定
			Gauge.SetMax(EnemysHp);//敵の満タン時のHP設定
			enemyType = "green";
			break;
		case 3:
			chara3.SetActive (true);
			P_damageMotion = chara3;
			P_Motion = chara3;  //自分のモーション
			status = chara3.GetComponent<Status>();
			characterAttack = status.PostAttack();
			characterAttack_S = characterAttack*2;
			characterHp = status.PostHp();
			P_Gauge.P_SetMax(characterHp);
			playerType = "green";
			
			//敵ステータス
			Enemy.SetActive (true);//赤敵
			damageMotion = Enemy;
			Motion = Enemy;  //敵のモーション
			Enemystatus = Enemy.GetComponent<Status>();//自分の初期ステータス設定
			EnemysAttack = Enemystatus.PostAttack();//敵の攻撃力設定
			EnemysHp = Enemystatus.PostHp();//敵のダメージ処理に使うHP設定
			Gauge.SetMax(EnemysHp);//敵の満タン時のHP設定
			enemyType = "red";
			break;
		default:
			break;
		}
		iTween.ScaleTo (P_Motion, iTween.Hash ("y", 55, "time", 2.0f, "easetype", "easeInCubic","LoopType","pingPong"));
		iTween.ScaleFrom (Motion, iTween.Hash ("y", 55, "time", 2.0f,"LoopType","pingPong","Delay",0.2));
	}

	public void EnemyAttackMove(){

			Invoke ("EnemyAttack", 1.5f);


	}
	public void EnemyAttack(){
		if(ballScript.isPlaying){
			if (Gauge.gaugeNow > 0) {
				if (EnemysCount < 1) {
					GetComponent<AudioSource>().PlayOneShot(charaDamage);
					characterHp = characterHp - EnemysAttack;
					iTween.PunchPosition (P_damageMotion.gameObject, iTween.Hash (
						"x", 8,
						"y", 8,
						"time", 5.0f));
					iTween.ShakePosition(mainCamera,iTween.Hash("x",3.0f,"y",3.0f,"time",0.5f));
					EnemysCount = 3;
					EnemyCount.score = 3;
					iTween.ScaleFrom (eCount, iTween.Hash ("x", 0,"time",0.2));
				}
			}
		}
	}
	public void PlayerAttack(){
		EnemysHp = EnemysHp - characterAttack;
		damegeTxst = damegeTxst + characterAttack;

		iTween.PunchPosition(damageMotion.gameObject, iTween.Hash(
			"x", 8,
			"y", 8,
			"time", 5.0f)
		                     );

	}
	public void PlayerAttack_S(){
		EnemysHp = EnemysHp - characterAttack_S;
		damegeTxst = damegeTxst + characterAttack_S;
		iTween.PunchPosition(damageMotion.gameObject, iTween.Hash(
			"x", 8,
			"y", 8,
			"time", 5.0f)
		                     );
		
	}
	public void enemyCount(){//敵の後壁ターンテキスト
		if (ballScript.isPlaying) {
			EnemysCount = EnemysCount - 1;
			EnemyCount.score = EnemyCount.score - 1;
			iTween.ScaleFrom (eCount, iTween.Hash ("y", 0, "time", 0.2));
			if(EnemysCount <= 0 && EnemyCount.score <= 0){
				EnemysCount = 0;
				EnemyCount.score = 0;
				ballScript.attackPlaying = true;
			}

		}
	}
	public void PlayerHeel() {//回復

		characterHp = characterHp + 80;
		if (characterHp >= 650)characterHp = 650;
	}
	public void PlayerIntimidation() {//威嚇
		damegeTxst = damegeTxst + 1;
		EnemysCount = EnemysCount + 1;
		EnemyCount.score = EnemyCount.score + 1;
	}
	private void LeftClick(){
		Vector3 tapPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
		if(holdObj == null){//GameObjectを保持していないときのみ動作するように判定
			Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(tapPoint));//タッチされたところに存在するスプライトを取得する処理です。
			if(col != null && col.gameObject.tag == "tile"){//タッチしたところにスプライトが存在しているときのみ、スプライトを保持して、また、初期座標をプロパティに保管
				this.holdObj = col.gameObject;
				holdPositionX = this.holdObj.transform.position.x;
				holdPositionY = this.holdObj.transform.position.y;
				holdObj.transform.position = Camera.main.ScreenToWorldPoint(tapPoint);
			}
		}
		
	}
	private void LeftDrag(){
		Vector3 tapPoint = Input.mousePosition;
		if(holdObj != null){
			this.holdObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z));//保持しているGameObjectの座標を変更※ドラッグしているときは常に呼ばれる
			Collider2D[] colSet = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z)));//クリック（タッチ）したところに存在するスプライト重なっているものを含めて全て取得する

			if(colSet.Length > 1){//現在保持しているスプライトとスプライトが重なった場合、スプライトの数は2なので、1より大きいときのみ入れ替えの処理をするように判定
				foreach(Collider2D col in colSet){//foreachで配列の全てを処理して、現在保持しているGameObjectではないGameObjectがあった場合は座標を入れ替えるように処理
					if(!col.gameObject.Equals(this.holdObj)){
						float tmpPositionX = holdPositionX;
						float tmpPositionY = holdPositionY;
						holdPositionX = col.gameObject.transform.position.x;
						holdPositionY = col.gameObject.transform.position.y;
						col.gameObject.transform.position = new Vector3(tmpPositionX, tmpPositionY, z);

						/*Sprite spriteImage = Resources.Load("TileLine", typeof(Sprite)) as Sprite;
						new GameObject("Sprite").AddComponent<SpriteRenderer>().sprite = spriteImage;*/
						//col.gameObject.transform.position = new Vector3(tmpPositionX, tmpPositionY, z);
					}
				}
			}
		}
	}
	private void LeftUp(){
		bool conFlg = true;
		if(holdObj != null){
			holdObj.transform.position = new Vector3(holdPositionX, holdPositionY, z);
			holdObj = null;
		}
		SetTileSet();

		while(conFlg){
			conFlg = false;
			DeleteMatchTile();
			foreach(bool deleteFlg in deleteTable){
				if(deleteFlg){
					conFlg = true;
					break;
				}
			}
			deleteTable = new bool[TileLineNum, TileColNum];
			tileTable = new int[TileLineNum,TileColNum];
		}
	}

	private void SetTileSet(){
		GameObject[,] tileSet = new GameObject[TileLineNum,TileColNum];
		for(int i = 0; i < TileLineNum; i++){
			for(int j = 0; j < TileColNum; j++){
				Collider2D col = Physics2D.OverlapPoint(new Vector2(FirstTilePosX + TileWidth * j, FirstTilePosY + TileHeight * i));
				if("tile".Equals(col.tag)){
					tileSet[i,j] = col.gameObject;
				}
			}
		}
		
		this.tileSet = tileSet;
	}
	private void SetTileLineSet(){
		GameObject[,] tilelineSet = new GameObject[Line_TileLineNum,Line_TileColNum];
		for(int i = 0; i < Line_TileLineNum; i++){
			for(int j = 0; j < Line_TileColNum; j++){
				Collider2D col2 = Physics2D.OverlapPoint(new Vector2(Line_FirstTilePosX + Line_TileWidth * j, Line_FirstTilePosY + Line_TileHeight * i));
				if("tileline".Equals(col2.tag)){
					tilelineSet[i,j] = col2.gameObject;
				}
			}
		}
		this.tilelineSet = tilelineSet;
	}
	
	private void DeleteMatchTile(){
		int cnt = 0;
		for(int i = 0; i < TileLineNum; i++){
			for(int j = 0; j < TileColNum; j++){
				cnt = CompareHorizontal(i, j, cnt);
				cnt = CompareVertical(i, j, cnt);
			}
		}
		
		DeleteTile();
	}
	
	private int CompareHorizontal(int i, int j, int cnt){
		if(j + 1 < TileColNum){
			Sprite nowSprite = GetSprite(this.tileSet[i,j]);
			Sprite nextSprite = GetSprite(this.tileSet[i,j+1]);
			if(nowSprite.Equals(nextSprite)){
				if(tileTable[i, j] > 0){
					tileTable[i,j+1] = tileTable[i,j]; 
				}else{
					int cntInTile = ReCompareHorizontal(i, j, nowSprite);
					if(cntInTile > 0){
						tileTable[i,j] = cntInTile;
						tileTable[i,j+1] = cntInTile; 
					}else{
						cnt++;
						tileTable[i,j] = cnt;
						tileTable[i,j+1] = cnt; 
					}
				}
			}
		}
		return cnt;
	}
	
	private int ReCompareHorizontal(int i, int j, Sprite baseSprite){
		int result = 0; 
		if(j + 1 < TileColNum){
			Sprite nextSprite = GetSprite (this.tileSet[i, j+1]);
			if(baseSprite.Equals(nextSprite)){
				if(tileTable[i,j+1] > 0){
					result = tileTable[i, j+1];
				}else{
					result = ReCompareHorizontal(i, j+1, baseSprite);
				}
			}else{
				result = 0;
			}
		}else{
			result = 0;
		}
		return result;
	}
	
	private int CompareVertical(int i, int j, int cnt){
		for(int k = 1; i + k < TileLineNum; k++){
			Sprite nowSprite = GetSprite (this.tileSet[i,j]);
			Sprite nextSprite = GetSprite(this.tileSet[i+k,j]);
			if(nowSprite.Equals(nextSprite)){
				if(tileTable[i,j] > 0){
					tileTable[i+k, j] = tileTable[i, j];
				}else{
					cnt++;
					tileTable[i,j] = cnt;
					tileTable[i+k,j] = cnt;
				}
			}else{
				break;
			}
		}
		
		return cnt;
	}
	
	private Sprite GetSprite(GameObject obj){
		SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
		return renderer.sprite;
	}
	
	private void DeleteTile(){
		SetDeleteTileSet();
		/*if(GetComponent<Renderer>() == Tiles[4]){
			Spdrop = 1;
			Debug.Log (Spdrop);
		}*/
		for(int i = 0; i < TileLineNum; i++){
			for(int j = 0; j < TileColNum; j++){
				if(deleteTable[i, j]){

					isPlaying = false;
					Destroy(this.tileSet[i,j]);
					scoreGUI.SendMessage ("AddPoint",point/* * remove_cnt*/);


					PlayerAttack();
					Invoke ("EnemyAttack", 3.0f);
					GameObject go = (GameObject)Instantiate (Effect01, this.tileSet[i,j].transform.position, Quaternion.identity);
					Destroy(go, 1.0f);
				}
			}
		}
		for(int i = 0; i < TileLineNum; i++){
			for(int j = 0; j < TileColNum; j++){
				if(deleteTable[i, j]){
					tileSet[i, j] = null;
				}
			}
		}
		FallTile();
		//RecreateTile();
		//Invoke("FallTile", 1.0f);
		//Invoke("RecreateTile", 1.0f);
	}
	
	private void SetDeleteTileSet(){//横のラインで考えて、左隣が同じIDを持っているかを見ています。
		//同じIDを持っている（色が同じである）限り、カウントアップを行い、色が変わった瞬間に、カウントが3以上であるかを判定。
		//	3以上であれば、今度は逆にカウントダウンをして右からtrueにしていく
		for(int i = 0; i < TileLineNum; i++){
			int cnt = 1;
			for(int j = 1; j < TileColNum; j++){
				if(tileTable[i, j] != 0 && tileTable[i, j - 1] == tileTable[i, j]){
					cnt++;
					if(j == TileColNum - 1){
						if(cnt > 2){
							for(int k = 0; k < cnt; k++){
								deleteTable[i, j - k] = true;
							}
						}
						cnt = 1;
					}
				}else{
					if(cnt > 2){
						for(int k = 1; k <= cnt; k++){
							deleteTable[i, j - k] = true;
						}
					}
					cnt = 1;
				}
			}
		}
		
		for(int i = 0; i < TileColNum; i++){
			int cnt = 1;
			for(int j = 1; j < TileLineNum; j++){
				if (tileTable[j, i] != 0 && tileTable[j - 1, i] == tileTable[j, i]){
					cnt++;
					if(j == TileLineNum - 1){
						if(cnt > 2){
							for(int k = 0; k < cnt; k++){
								deleteTable[j - k, i] = true;
							}
						}
						cnt = 1;
					}
				}else{
					if(cnt > 2){
						for(int k = 1; k <= cnt; k++){
							deleteTable[j - k, i] = true;
						}
					}
					cnt = 1;
				}
			}
		}
	}
	
	/*private void FallTile(){
		for(int i =0; i < TileColNum; i++){
			for(int j = 1; j < TileLineNum; j++){
				if(tileSet[j-1, i] == null && tileSet[j,i]!= null){
					GameObject obj = tileSet[j, i].gameObject;
					obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - TileHeight, z);
					tileSet[j-1,i] = obj;
					tileSet[j, i] = null;
					j = 0;
				}
			}
		}
	}*/
	private int fallTileNum = 0;

	private void FallTile() {
		for (int j = 0; j < TileLineNum; j++) {
			for (int i = 0; i < TileColNum; i++) {
				if (tileSet[i, j] == null) {
					for (int k = i+ 1; k < TileColNum; k++) {
						if (tileSet[k, j] != null) {
							GameObject obj = tileSet[k, j].gameObject;
							tileSet[i, j] = obj;
							tileSet[k, j] = null;
							
							fallTileNum++;
							
							Hashtable table = SetFallParams(FirstTilePosX + TileWidth * j, FirstTilePosY + TileHeight * i);
							iTween.MoveTo(tileSet[i, j], table);
							break;
						}
					}
				}
			}
			// 削除により補充されるタイルの落下後の座標を設定
			int addTileNum = 0;
			for (int i = 0; i < TileColNum; i++) {
				if (tileSet[i, j] == null) {
					RecreateTile(i, j, addTileNum);
					fallTileNum++;
					addTileNum++;

					Hashtable table = SetFallParams(FirstTilePosX + TileWidth * j, FirstTilePosY + TileHeight * i);
					iTween.MoveTo(tileSet[i, j], table);
					Invoke ("IsPlaying", 1.0f);
				}
			} 
		}
	}
	private void FallTileCompleteHandler() {
		if (--fallTileNum == 0) {
			//DeletePhase();
		}
	}


	
	private void RecreateTile(int i, int j, int offsetRow){
		GameObject tile = (GameObject)Instantiate(TileObj);
		SpriteRenderer renderer = tile.gameObject.GetComponent<SpriteRenderer>();
		renderer.sprite = Tiles[Random.Range (0, 5)];
		Vector3 pos = new Vector3(FirstTilePosX + TileWidth * j, FirstTilePosY + TileHeight * (TileColNum + offsetRow), z);
		tile.transform.position = pos;
		tileSet[i, j] = tile;
	}




	private Hashtable SetFallParams(float toX, float toY) {
		Hashtable table = new Hashtable();
		table.Add("x", toX);
		table.Add("y", toY);
		table.Add("time", 1.0f);
		table.Add("easetype", "easeInOutCubic");
		table.Add("oncomplete", "FallTileCompleteHandler");
		table.Add("oncompletetarget", this.gameObject);
		return table;
	}

	private void DeleteMatchTile2(){
		Vector3 tapPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
		Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(tapPoint));
		this.holdObj = col.gameObject;
		SpriteRenderer holdObjRenderer = holdObj.GetComponent<SpriteRenderer>();
		Sprite holdObjSprite = holdObjRenderer.sprite;

		for(int i = 0; i < TileLineNum; i++){
			for(int j = 0; j < TileColNum - 1; j++){
				try{
					GameObject nowObj = this.tileSet[i,j];
					GameObject nextObj = this.tileSet[i,j+1];

					SpriteRenderer nowRenderer = nowObj.GetComponent<SpriteRenderer>();
					SpriteRenderer nextRenderer = nextObj.GetComponent<SpriteRenderer>();
					Sprite nowSprite = nowRenderer.sprite;
					Sprite nextSprite = nextRenderer.sprite;
					if(!holdObjSprite.Equals(nextSprite)){
						Destroy(nowObj);
						Destroy(nextObj);
					}
				}catch{
				}
			}
		}
	}



	

	private void InitalizeTile(){
		for(int i = 0; i < TileLineNum; i++){
			for(int j = 0; j < TileColNum; j++){
				GameObject tile = tileSet[i, j];
				SpriteRenderer renderer = tile.gameObject.GetComponent<SpriteRenderer>();
				renderer.sprite = Tiles[Random.Range (0, 5)];

				while (checkInitalizeMatch(i, j)) {
					renderer.sprite = Tiles[Random.Range (0, 5)];
					    }
			}
		}
	}
	private bool checkInitalizeMatch(int i, int j) {
		bool isMatch = false;
		if (i >= 2) {
			Sprite beforeSprite1 = GetSprite(this.tileSet[i-2,j]);
			Sprite beforeSprite2 = GetSprite(this.tileSet[i-1,j]);
			Sprite currSprite = GetSprite(this.tileSet[i,j]);
			isMatch = beforeSprite1.Equals(currSprite) && beforeSprite2.Equals(currSprite);
		}
		if (!isMatch && j >= 2){
			Sprite beforeSprite1 = GetSprite(this.tileSet[i,j-2]);
			Sprite beforeSprite2 = GetSprite(this.tileSet[i,j-1]);
			Sprite currSprite = GetSprite(this.tileSet[i,j]);
			isMatch = beforeSprite1.Equals(currSprite) && beforeSprite2.Equals(currSprite);
		}
		return isMatch;
	}
	private void IsPlaying(){
		isPlaying = true;
	}
}
