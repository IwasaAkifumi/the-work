using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ballScript : MonoBehaviour {

	public GameObject mainCamera; //カメラの定義
	public bool isPlaying = false;
	public bool ballisPlaying = true;
	public bool enemyPlaying = true;
	public bool attackPlaying = false;
	public GameSystem GameSystem;
	public TimeScript TimeScript;
	public ScoreScript ScoreScript;
	
	public GameObject ballPrefab;
	public GameObject enemyballPrefab;
	public Sprite[] ballSprites;
	public Sprite[] spballSprites;
	public Sprite[] enemyballSprites;
	public GameObject UnderWall2;
	public GameObject playerSkill;


	private GameObject firstBall; //最初にドラッグしたボール
	private GameObject lastBall; //最後にドラッグしたボール
	private GameObject midsBall; //途中にドラッグしたボール


	public int skill = 0;
	public int comboC = 0;


	public string currentName; //名前判定用のstring変数
	//削除するボールのリスト
	List<GameObject> removableBallList = new List<GameObject>();

	public float timeOut = 10f;
	private float timeElapsed;

	public GameObject scoreGUI;
	public GameObject comboGUI;
	public GameObject countGUI;
	public GameObject damageGUI;
	private int point = 100;

	// 再生したいEffectのプレハブを指定する
	public GameObject Effect = null;
	public GameObject Effect01 = null;
	public GameObject Effect02 = null;
	public GameObject Effect03 = null;
	public GameObject comboEffect = null;

	private GameObject enemyDrop0;

	public GameObject cutin;public GameObject cutin_2;public GameObject cutin_3;
	public GameObject cutin0;
	public GameObject cutin1;
	public GameObject cutin2;
	public GameObject cutinChara;public GameObject cutinChara2;public GameObject cutinChara3;
	public GameObject cutinChara1_1;public GameObject cutinChara2_1;public GameObject cutinChara3_1;

	public GameObject cutinEnemy;public GameObject cutinEnemy_2;public GameObject cutinEnemy_3;
	public GameObject cutinEnemy0;
	public GameObject cutinEnemy1;
	public GameObject cutinEnemy2;
	public GameObject cutinCharaEnemy;public GameObject cutinCharaEnemy2;public GameObject cutinCharaEnemy3;
	public GameObject cutinCharaEnemy1_1;public GameObject cutinCharaEnemy2_1;public GameObject cutinCharaEnemy3_1;

	public GameObject skill_1;
	public GameObject skill2_1;
	public GameObject skill3_1;

	public GameObject skillText;

	//音声ファイル格納用変数
	public AudioClip dropDelete;
	public AudioClip dropConversion;
	public AudioClip buttonOn;
	public AudioClip skillin;
	public AudioClip redAttack;
	public AudioClip blueAttack;
	public AudioClip greenAttack;
	public AudioClip gameoverOn;
	public AudioClip gameclearOn;
	public AudioClip countOn;

	private int count2 = 1;
	private float time2;
	private float time2_1;

	public GameObject attackEffect_F;
	public GameObject attackEffect_f;
	public GameObject attackEffect_W;
	public GameObject attackEffect_w;
	public GameObject attackEffect_M;
	public GameObject attackEffect_m;
	public GameObject attackEffect_h;

	void Start () {
		//StartCoroutine(DropBall(50));
		isPlaying = false;
		comboEffect.SetActive (false);
		cutin.SetActive (false);

		GameObject GameSystem = GameObject.Find("GameSystem");
		GameObject ScoreScript = GameObject.Find("ScoreScript");

		skill_1.SetActive (false);
		skill2_1.SetActive (false);
		skill3_1.SetActive (false);

		GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "";
		GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "";
		skillText = GameObject.Find ("Combo");
		removableBallList = new List<GameObject>();

	}

	void Update () {
		if (isPlaying && ballisPlaying) {
		timeElapsed += Time.deltaTime;
		
		if(timeElapsed >= timeOut) {
			StartCoroutine(DropBall(14));
			StartCoroutine(SpDropBall(1));
			timeElapsed = 0.0f;
			}

		}
		if (isPlaying && ballisPlaying) {
			if (GameSystem.EnemysCount < 1) {
				GameSystem.EnemyAttackMove ();
				if (GameSystem.enemyType == "red") {
					GameObject go = (GameObject)Instantiate (attackEffect_F, new Vector3 (-100, 30, -2), Quaternion.identity);
					Destroy (go, 0.5f);
				}
				if (GameSystem.enemyType == "blue") {
					GameObject go = (GameObject)Instantiate (attackEffect_W, new Vector3 (-100, 30, -2), Quaternion.identity);
					Destroy (go, 0.5f);
				}
				if (GameSystem.enemyType == "green") {
					GameObject go = (GameObject)Instantiate (attackEffect_M, new Vector3 (-100, 30, -2), Quaternion.identity);
					Destroy (go, 0.5f);
				}
				attackPlaying = false;
			}
		}
		ComboSkill ();
		SkillGauge ();
		//画面をクリックし、firstBallがnullの時実行
		if (isPlaying) {
			if (Input.GetMouseButtonDown (0) && firstBall == null && midsBall == null) {
				PlayerSkill ();
				OnDragStart ();

			} else if (Input.GetMouseButtonUp (0)) {
				//クリックを終えた時
				OnDragEnd ();
				//OnDragStartメソッド実行後
			} else if (firstBall != null) {
				OnDragging ();

			}
		}
	}

	private void OnDragStart() {
		ScoreScript.RemoveCount ();
		count2 = 1;
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
		if (hit.collider != null) {
			GameObject hitObj = hit.collider.gameObject;

			//オブジェクトの名前を前方一致で判定
			string ballName = hitObj.name;
			if (ballName.StartsWith ("Drop")) {

				countGUI.SendMessage ("AddCount",count2);
				firstBall = hitObj;
				midsBall = hitObj;
				lastBall = hitObj;
				currentName = hitObj.name;
				//削除対象オブジェクトリストの初期化
				removableBallList = new List<GameObject>();
				//削除対象のオブジェクトを格納
				if(lastBall.name == "Drop0"){
					PushToList(hitObj);
				}
				if(lastBall.name == "Drop1"){
					PushToList2(hitObj);
				}
				if(lastBall.name == "Drop2"){
					PushToList3(hitObj);
				}
			}
		}
	}
	private void OnDragging (){
		GameObject spDrop0 = GameObject.Find("spDrop0");
		GameObject enemyDrop0 = GameObject.Find("enemyDrop0");

		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
		if (hit.collider != null) {
			GameObject hitObj = hit.collider.gameObject;

			if (hitObj.name == spDrop0.name){
				hitObj.name = currentName;
			}
			if (hitObj.name == enemyDrop0.name){
				OnDragEnd ();
				Count2();
				comboGUI.SendMessage ("RemoveCombo");
			}
			/*if (hitObj.name == spDrop1.name){
				//currentName = hitObj.name;
				currentName = hitObj.name;
				//hitObj.name = currentName;
			}
			if (currentName == spDrop1.name && hitObj.name == Drop0.name || hitObj.name == Drop1.name || hitObj.name == Drop2.name){
				currentName = hitObj.name;
				hitObj.name = currentName;
			}*/
			//同じ名前のブロックをクリック＆lastBallとは別オブジェクトである時
			if (hitObj.name == currentName && lastBall != hitObj && firstBall != hitObj) {
				//２つのオブジェクトの距離を取得
				float distance = Vector2.Distance (hitObj.transform.position, lastBall.transform.position);
				if (distance < 100.0f) {
					GetComponent<AudioSource>().PlayOneShot(countOn);
					//削除対象のオブジェクトを格納
					//midsBall = lastBall;
					count2 = count2 + 1;
					countGUI.SendMessage ("AddCount",count2);
					lastBall = hitObj;

					if(lastBall.name == "Drop0"){
						PushToList(hitObj);
					}
					if(lastBall.name == "Drop1"){
						PushToList2(hitObj);
					}
					if(lastBall.name == "Drop2"){
						PushToList3(hitObj);
					}
				}
			}
		}
	}
	private void OnDragEnd () {
		GameObject Drop0 = GameObject.Find("Drop0");
		GameObject Drop1 = GameObject.Find("Drop1");
		GameObject Drop2 = GameObject.Find("Drop2");
		midsBall = null;
		int remove_cnt = removableBallList.Count;
		if (remove_cnt >= 3) {
			GetComponent<AudioSource>().PlayOneShot(dropDelete);
			comboGUI.SendMessage ("AddCombo",remove_cnt);//コンボ加算
			//countGUI.SendMessage ("AddCount",remove_cnt);
			if(comboC < ScoreScript.combo)comboC = ScoreScript.combo;
			for (int i = 0; i < remove_cnt; i++) {
				if(GameSystem.playerType == "red"){//キャラクター1を選択

					if(currentName == Drop0.name){
						GetComponent<AudioSource>().PlayOneShot(redAttack);
						GameSystem.PlayerAttack_S();
						GameObject go = (GameObject)Instantiate(attackEffect_F,new Vector3(100,30,-2),Quaternion.identity);
						Destroy(go, 0.5f);

					}else if (currentName == Drop1.name) {
						GetComponent<AudioSource>().PlayOneShot(blueAttack);
						GameSystem.PlayerAttack();
						GameObject go = (GameObject)Instantiate(attackEffect_w,new Vector3(100,30,-2),Quaternion.identity);
						Destroy(go, 0.5f);
					}else if (currentName == Drop2.name) {
						GetComponent<AudioSource>().PlayOneShot(greenAttack);
						GameSystem.PlayerAttack();
						GameObject go = (GameObject)Instantiate(attackEffect_m,new Vector3(100,30,-2),Quaternion.identity);
						Destroy(go, 0.5f);
					}
				}


				if(GameSystem.playerType == "blue"){//キャラクター2を選択
					if(currentName == Drop1.name){
						GetComponent<AudioSource>().PlayOneShot(blueAttack);
						GameSystem.PlayerAttack_S();
						GameObject go = (GameObject)Instantiate(attackEffect_W,new Vector3(100,30,-2),Quaternion.identity);
						Destroy(go, 0.5f);
					}else if(currentName == Drop0.name){
						GetComponent<AudioSource>().PlayOneShot(redAttack);
						GameSystem.PlayerAttack();
						GameObject go = (GameObject)Instantiate(attackEffect_f,new Vector3(100,30,-2),Quaternion.identity);
						Destroy(go, 0.5f);
					}else if(currentName == Drop2.name){
						GetComponent<AudioSource>().PlayOneShot(greenAttack);
						GameSystem.PlayerAttack();
						GameObject go = (GameObject)Instantiate(attackEffect_m,new Vector3(100,30,-2),Quaternion.identity);
						Destroy(go, 0.5f);
					}
				}



				if(GameSystem.playerType == "green"){//キャラクター3を選択
					if(currentName == Drop2.name){
						GetComponent<AudioSource>().PlayOneShot(greenAttack);
						GameSystem.PlayerAttack_S();
						GameObject go = (GameObject)Instantiate(attackEffect_M,new Vector3(100,30,-2),Quaternion.identity);
						Destroy(go, 0.5f);
					}else if(currentName == Drop0.name){
						GetComponent<AudioSource>().PlayOneShot(redAttack);
						GameSystem.PlayerAttack();
						GameObject go = (GameObject)Instantiate(attackEffect_f,new Vector3(100,30,-2),Quaternion.identity);
						Destroy(go, 0.5f);
					}else if(currentName == Drop1.name){
						GetComponent<AudioSource>().PlayOneShot(blueAttack);
						GameSystem.PlayerAttack();
						GameObject go = (GameObject)Instantiate(attackEffect_w,new Vector3(100,30,-2),Quaternion.identity);
						Destroy(go, 0.5f);
					}
				}

				//GameSystem.PlayerAttack();
				damageGUI.SendMessage ("AddDamage",GameSystem.damegeTxst);//でめーじテキストに送る
				scoreGUI.SendMessage ("AddPoint",point * remove_cnt);//スコアを加算

				skill = skill + 1;

				Destroy (removableBallList [i]);
				if(lastBall.name == "Dropremova"){
					GameObject go = (GameObject)Instantiate (Effect01, removableBallList [i].transform.position, Quaternion.identity);
					Destroy(go, 0.5f);
				}
				if(lastBall.name == "Dropremova2"){
					GameObject go = (GameObject)Instantiate (Effect02, removableBallList [i].transform.position, Quaternion.identity);
					Destroy(go, 0.5f);
				}
				if(lastBall.name == "Dropremova3"){
					GameObject go = (GameObject)Instantiate (Effect03, removableBallList [i].transform.position, Quaternion.identity);
					Destroy(go, 0.5f);
				}
			}

			GameSystem.enemyCount();

			if(!enemyPlaying){
				StartCoroutine(EnemyDropBall(5));
			}
			if(enemyPlaying){
				Invoke ("EnemyPlaying", 10.0f);
			}
			//StartCoroutine (DropBall (remove_cnt));//ボールを新たに生成
		} else {
			//色の透明度を100%に戻す
			for (int i = 0; i < remove_cnt; i++) {
				ChangeColor (removableBallList[i],1.0f);
			}
		}
		firstBall = null;
		lastBall = null;
		currentName = null;
		removableBallList = new List<GameObject>();
		GameSystem.damegeTxst = 0;
		Invoke ("RemoveDamegeTxst", 1.0f);
	}
	public void Count2(){
		count2 = 0;
		countGUI.SendMessage ("AddCount",count2);
	}
	public void RemoveDamegeTxst(){//一定時間でダメージテキストを非表示
		scoreGUI.SendMessage ("RemoveDamage");
	}
	private void ComboSkill () {//50コンボでスキル発動
		if(isPlaying){
			if (ScoreScript.comboSkill >= 50) {
				GetComponent<AudioSource>().PlayOneShot(skillin);
				time2 = TimeScript.time;
				time2_1 = TimeScript.time;
				enemyPlaying = true;
				ballisPlaying = false;
				UnderWall2.SetActive (true);
				playerSkill.SetActive (true);
				iTween.MoveFrom(UnderWall2, iTween.Hash("y", -500f,"time", 1.5f,"isLocal",true));
				iTween.MoveFrom(playerSkill, iTween.Hash("x", -800f,"time", 0.5f,"isLocal",true));
				comboEffect.SetActive (true);
				Invoke ("PlayerSkilleffect", 2.0f);



				CharaSkill2();
				ScoreScript.comboSkill = -50;
			}

		}
		if (isPlaying && TimeScript.timeisPlaying) {
			time2 -= Time.deltaTime;
		}
		if(time2_1-10 >= time2){
			UnderWall();
		}
	}
	private void PlayerSkill () {
		RaycastHit2D hitChara = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
		if (hitChara.collider != null) {
			GameObject hitObj = hitChara.collider.gameObject;

			if (skill >= 25) {
			
			switch (hitObj.name) {
			case "Chara":
					Debug.Log ("charaを押した");
					Invoke ("CutinFalse", 3.0f);
					CharaCutin ();
					if(skill >= 25 && skill < 50){
						GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "ハイドランスブレイク";
						GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "お邪魔スターを削除";
						Invoke ("CharaSkill2", 1.0f);
						SkillGaugeFalse ();
						skill = -25;
					} else if(skill >= 50 && skill < 75){
						GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "ザ・ワールド";
						GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "一定時間スターを止める";
						Invoke ("CharaSkill3", 1.0f);
						SkillGaugeFalse ();
						skill = -50;
					} else if(skill >= 75){
						GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "オールスタイルチェンジ";
						GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "全スターを同じ色に変換";
						Invoke ("Chara1Skill", 1.0f);
						SkillGaugeFalse ();
						skill = -75;
					}

				break;
			case "Chara2":
				Debug.Log ("chara2を押した");
					CharaCutin ();
					Invoke ("CutinFalse", 3.0f);
					if(skill >= 25 && skill < 50){
						GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "ターンエクステンド";
						GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "敵の攻撃を1ターン延長";
						Invoke ("CharaSkill5", 1.0f);
						SkillGaugeFalse ();
						skill = -25;
					} else if(skill >= 50 && skill < 75){
						GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "ザ・ワールド";
						GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "一定時間スターを止める";
						Invoke ("CharaSkill3", 1.0f);
						SkillGaugeFalse ();
						skill = -50;
					} else if(skill >= 75){
						GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "オールスタイルチェンジ";
						GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "全スターを同じ色に変換";
						Invoke ("Chara2Skill", 1.0f);
						SkillGaugeFalse ();
						skill = -75;
					}

				break;
			case "Chara3":
					Debug.Log ("chara3を押した");
					CharaCutin ();
					Invoke ("CutinFalse", 3.0f);
					if(skill >= 25 && skill < 50){
						GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "ヒールケア";
						GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "体力を少々回復";
						Invoke ("CharaSkill4", 3.0f);
						SkillGaugeFalse ();
						skill = -25;
					} else if(skill >= 50 && skill < 75){
						GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "ザ・ワールド";
						GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "一定時間スターを止める";
						Invoke ("CharaSkill3", 1.0f);
						SkillGaugeFalse ();
						skill = -50;
					} else if(skill >= 75){
						GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "オールスタイルチェンジ";
						GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "全スターを同じ色に変換";
						Invoke ("Chara3Skill", 1.0f);
						SkillGaugeFalse ();
						skill = -75;
					}

				break;
				case "Ememy3":

					break;
			}
			
			}
		}
	}
	private void SkillGauge () {//スキルゲージの表示
		if(skill >= 25){
			skill_1.SetActive (true);
		}
		if(skill >= 50){
			skill2_1.SetActive (true);
		}
		if(skill >= 75 ){
			skill3_1.SetActive (true);
		}
	}
	private void SkillGaugeFalse () {//スキルゲージの非表示
		skill_1.SetActive (false);
		skill2_1.SetActive (false);
		skill3_1.SetActive (false);
	}

	private void CharaCutin () {//キャラカットイン
		switch (PlayerPrefs.GetInt ("name")) {
		case 1:
			GetComponent<AudioSource>().PlayOneShot(skillin);
			cutin.SetActive (true);
			iTween.MoveFrom (cutin1, iTween.Hash ("x", 800f, "time", 2.0f, "isLocal", true));
			iTween.MoveFrom (cutin2, iTween.Hash ("x", -800f, "time", 2.0f, "isLocal", true));
			iTween.MoveFrom (cutinChara, iTween.Hash ("x", -800f, "time", 1.0f, "isLocal", true));
			//iTween.MoveFrom (skillText, iTween.Hash ("x", -800f, "time", 1.0f, "isLocal", true));
			iTween.MoveFrom (cutinChara1_1, iTween.Hash ("x", 800f, "time", 1.0f, "isLocal", true));
			//iTween.FadeTo(cutin, iTween.Hash("alpha", 0, "time", 0.5f,"Delay",3));
			break;
		case 2:
			GetComponent<AudioSource>().PlayOneShot(skillin);
			cutin_2.SetActive (true);
			iTween.MoveFrom(cutin1, iTween.Hash("x", 800f,"time", 2.0f,"isLocal",true));
			iTween.MoveFrom(cutin2, iTween.Hash("x", -800f,"time", 2.0f,"isLocal",true));
			iTween.MoveFrom(cutinChara2, iTween.Hash("x", -800f,"time", 1.0f,"isLocal",true));
		//	iTween.MoveFrom (skillText, iTween.Hash ("x", -800f, "time", 1.0f, "isLocal", true));
			iTween.MoveFrom(cutinChara2_1, iTween.Hash("x", 800f,"time", 1.0f,"isLocal",true));
			//iTween.FadeTo(cutin, iTween.Hash("alpha", 0, "time", 0.5f,"Delay",3));
			break;
		case 3:
			GetComponent<AudioSource>().PlayOneShot(skillin);
			cutin_3.SetActive (true);
			iTween.MoveFrom(cutin1, iTween.Hash("x", 800f,"time", 2.0f,"isLocal",true));
			iTween.MoveFrom(cutin2, iTween.Hash("x", -800f,"time", 2.0f,"isLocal",true));
			iTween.MoveFrom(cutinChara3, iTween.Hash("x", -800f,"time", 1.0f,"isLocal",true));
		//	iTween.MoveFrom (skillText, iTween.Hash ("x", -800f, "time", 1.0f, "isLocal", true));
			iTween.MoveFrom(cutinChara3_1, iTween.Hash("x", 800f,"time", 1.0f,"isLocal",true));
			//iTween.FadeTo(cutin, iTween.Hash("alpha", 0, "time", 0.5f,"Delay",3));
			break;
		}
	}
	public void CharaCutinEnemy () {//敵キャラカットイン
		GetComponent<AudioSource>().PlayOneShot(skillin);
		GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "スキルパラサイト";
		GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "特定の色をお邪魔ドロップに変える";
		cutinEnemy.SetActive (true);
		iTween.MoveFrom(cutinEnemy1, iTween.Hash("x", 800f,"time", 2.0f,"isLocal",true));
		iTween.MoveFrom(cutinEnemy2, iTween.Hash("x", -800f,"time", 2.0f,"isLocal",true));
		iTween.MoveFrom(cutinCharaEnemy, iTween.Hash("x", -800f,"time", 1.0f,"isLocal",true));
		iTween.MoveFrom(cutinCharaEnemy1_1, iTween.Hash("x", 800f,"time", 1.0f,"isLocal",true));
	}
	public void CharaCutinEnemy2 () {//敵キャラカットイン
		GetComponent<AudioSource>().PlayOneShot(skillin);
		GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "スキルパラサイト";
		GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "特定の色をお邪魔ドロップに変える";
		cutinEnemy_2.SetActive (true);
		iTween.MoveFrom(cutinEnemy1, iTween.Hash("x", 800f,"time", 2.0f,"isLocal",true));
		iTween.MoveFrom(cutinEnemy2, iTween.Hash("x", -800f,"time", 2.0f,"isLocal",true));
		iTween.MoveFrom(cutinCharaEnemy2, iTween.Hash("x", -800f,"time", 1.0f,"isLocal",true));
		iTween.MoveFrom(cutinCharaEnemy2_1, iTween.Hash("x", 800f,"time", 1.0f,"isLocal",true));
	}
	public void CharaCutinEnemy3 () {//敵キャラカットイン
		GetComponent<AudioSource>().PlayOneShot(skillin);
		GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "スキルパラサイト";
		GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "特定の色をお邪魔ドロップに変える";
		cutinEnemy_3.SetActive (true);
		iTween.MoveFrom(cutinEnemy1, iTween.Hash("x", 800f,"time", 2.0f,"isLocal",true));
		iTween.MoveFrom(cutinEnemy2, iTween.Hash("x", -800f,"time", 2.0f,"isLocal",true));
		iTween.MoveFrom(cutinCharaEnemy3, iTween.Hash("x", -800f,"time", 1.0f,"isLocal",true));
		iTween.MoveFrom(cutinCharaEnemy3_1, iTween.Hash("x", 800f,"time", 1.0f,"isLocal",true));
	}

	private void Chara1Skill () {//キャラ1のスキル（全星を同じ色にする）
		GameObject[] Drop = GameObject.FindGameObjectsWithTag("Block");
		foreach(GameObject obs in Drop) {
			iTween.ScaleFrom (obs, iTween.Hash ("x", 1, "y", 1,"time",0.3));
			SpriteRenderer spriteObj = obs.GetComponent<SpriteRenderer>();
			spriteObj.sprite = ballSprites[0];
			obs.name = "Drop0";
		}
	}
	private void Chara2Skill () {//キャラ2のスキル（全星を同じ色にする）
		GameObject[] Drop = GameObject.FindGameObjectsWithTag("Block");
		foreach(GameObject obs in Drop) {
			iTween.ScaleFrom (obs, iTween.Hash ("x", 1, "y", 1,"time",0.3));
			SpriteRenderer spriteObj = obs.GetComponent<SpriteRenderer>();
			spriteObj.sprite = ballSprites[1];
			obs.name = "Drop1";
		}
	}
	private void Chara3Skill () {//キャラ3のスキル（全星を同じ色にする）
		GameObject[] Drop = GameObject.FindGameObjectsWithTag("Block");
		foreach(GameObject obs in Drop) {
			iTween.ScaleFrom (obs, iTween.Hash ("x", 1, "y", 1,"time",0.3));
			SpriteRenderer spriteObj = obs.GetComponent<SpriteRenderer>();
			spriteObj.sprite = ballSprites[2];
			obs.name = "Drop2";
		}
	}
	private void CharaSkill2() {//敵お邪魔星を全て削除する
		GameObject[] EnemyDrop = GameObject.FindGameObjectsWithTag("EnemyDrop");
		foreach(GameObject obs in EnemyDrop) {
			Destroy(obs);
			GameObject go = (GameObject)Instantiate (Effect, obs.transform.position, Quaternion.identity);
			Destroy(go, 1.0f);
		}
	}
	private void CharaSkill3() {//流れを止める
		GameObject[] Drop = GameObject.FindGameObjectsWithTag ("Block");
		foreach (GameObject obs in Drop) {
			Vector3 localGravity;
			Rigidbody2D rb = obs.GetComponent<Rigidbody2D> ();
			rb.isKinematic = true;

		}
		GameObject[] Drope = GameObject.FindGameObjectsWithTag ("EnemyDrop");
		foreach (GameObject obs in Drope) {
			Rigidbody2D rb = obs.GetComponent<Rigidbody2D> ();
			rb.isKinematic = true;
		}
		ballisPlaying = false;
		//isPlaying = false;
		TimeScript.timeisPlaying = false;
		Invoke ("CharaSkill3_2", 5.0f);
	}
	private void CharaSkill3_2() {//流れを動かす
		GameObject[] Drop = GameObject.FindGameObjectsWithTag ("Block");
		foreach (GameObject obs in Drop) {
			Rigidbody2D rb = obs.GetComponent<Rigidbody2D> ();
			rb.isKinematic = false;
		}
		GameObject[] Drope = GameObject.FindGameObjectsWithTag ("EnemyDrop");
		foreach (GameObject obs in Drope) {
			Rigidbody2D rb = obs.GetComponent<Rigidbody2D> ();
			rb.isKinematic = false;
		}
		ballisPlaying = true;
		//isPlaying = true;
		TimeScript.timeisPlaying = true;
	}
	private void CharaSkill4() {//回復
		GameSystem.PlayerHeel ();
		GameObject go = (GameObject)Instantiate(attackEffect_h,new Vector3(-100,30,-2),Quaternion.identity);
		Destroy(go, 0.3f);
	}
	private void CharaSkill5() {//威嚇
		GameSystem.PlayerIntimidation();
	}
	private void CutinFalse () {//全てのカットインを非表示にする
		GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "";
		GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "";
		cutin.SetActive (false);
		cutin_2.SetActive (false);
		cutin_3.SetActive (false);
	}
	void OnCompleteHandler(){//コンボスキルのカットインモーション
		iTween.MoveTo(playerSkill, iTween.Hash("x", 800f,"time", 1.5f,"isLocal",true,"Delay",1));
	}
	private void UnderWall () {
		comboEffect.SetActive (false);
		UnderWall2.SetActive (false);

		//Time.timeScale = 0;
	}
	private void PlayerSkilleffect () {
		iTween.MoveTo(playerSkill, iTween.Hash("x", -800f,"time", 1.5f,"isLocal",true));
		playerSkill.SetActive (false);

		ballisPlaying = true;
		
		//Time.timeScale = 0;
	}


	IEnumerator DropBall(int count) {
		for (int i = 0; i < count; i++) {
			Vector2 pos = new Vector2(Random.Range(-150.0f, 150.0f), 7f);
			GameObject ball = Instantiate(ballPrefab, pos, Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;
			int spriteId = Random.Range(0, 3);
			ball.name = "Drop" + spriteId;
			SpriteRenderer spriteObj = ball.GetComponent<SpriteRenderer>();
			spriteObj.sprite = ballSprites[spriteId];
			yield return new WaitForSeconds(0.05f);
		}
	}
	IEnumerator SpDropBall(int count) {
		for (int i = 0; i < count; i++) {
			Vector2 pos = new Vector2(Random.Range(-150.0f, 150.0f), 7f);
			GameObject spball = Instantiate(ballPrefab, pos, Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;
			int spriteId = Random.Range(0, 1);
			spball.name = "spDrop" + spriteId;
			SpriteRenderer spriteObj = spball.GetComponent<SpriteRenderer>();
			spriteObj.sprite = spballSprites[spriteId];
			yield return new WaitForSeconds(0.1f);
		}
	}
	IEnumerator EnemyDropBall(int count) {
		for (int i = 0; i < count; i++) {
			Vector2 pos = new Vector2(Random.Range(-150.0f, 150.0f), 7f);
			GameObject ball = Instantiate(enemyballPrefab, pos, Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;
			int spriteId = Random.Range(0, 1);
			ball.name = "enemyDrop" + spriteId;
			SpriteRenderer spriteObj = ball.GetComponent<SpriteRenderer>();
			spriteObj.sprite = enemyballSprites[spriteId];
			yield return new WaitForSeconds(0.1f);
		}
	}
	void PushToList (GameObject obj) {
		removableBallList.Add (obj);
		//色の透明度を50%に落とす
		ChangeColor(obj, 0.5f);
		obj.tag = ("Dropremova");
		//obj.layer = ("Dropremova");
		obj.name = "Dropremova";
	}
	void PushToList2 (GameObject obj) {
		removableBallList.Add (obj);
		//色の透明度を50%に落とす
		ChangeColor(obj, 0.5f);
		obj.tag = ("Dropremova");
		//obj.layer = ("Dropremova");
		obj.name = "Dropremova2";
	}
	void PushToList3 (GameObject obj) {
		removableBallList.Add (obj);
		//色の透明度を50%に落とす
		ChangeColor(obj, 0.5f);
		obj.tag = ("Dropremova");
		//obj.layer = ("Dropremova");
		obj.name = "Dropremova3";
	}
	void ChangeColor (GameObject obj, float transparency) {
		//SpriteRendererコンポーネントを取得
		SpriteRenderer ballTexture = obj.GetComponent<SpriteRenderer>();
		//Colorプロパティのうち、透明度のみ変更する
		ballTexture.color = new Color(ballTexture.color.r, ballTexture.color.g, ballTexture.color.b, transparency);
	}

	private void IsPlaying(){
		isPlaying = true;
	}
	private void EnemyPlaying () {
		enemyPlaying = false;
	}
}