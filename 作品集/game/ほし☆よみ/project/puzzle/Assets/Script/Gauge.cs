using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gauge : MonoBehaviour {
	private float gaugeMax;
	public float gaugeNow;
	public GameObject gameClearText;
	public GameSystem GameSystem;
	public TimeScript TimeScript;
	public ballScript ballScript;
	public ScoreScript ScoreScript;
	Transform t;
	Transform t_2;
	bool One = true;
	bool One2 = true;

	public GameObject Effect01 = null;
	public GameObject nextStage;
	public GameObject clearScore;
	public GameObject clearScore1;
	public GameObject clearCombo;
	public GameObject clearTime;
	public GameObject overallTime;
	public GameObject rankText;

	public GameObject sucoreRank_2;
	public GameObject sucoreRank2_2;
	public GameObject comboRank_2;
	public GameObject comboRank2_2;
	public GameObject timeRank_2;
	public GameObject timeRank2_2;
	public GameObject yesBtn;

	public int rankCount = 0;

	public GameObject EnemyCount;

	public AudioClip gameclearOn;
	public AudioClip buttonOn;

	public Sprite[] ballSprites;
	public int i=0;


	// Use this for initialization
	void Start () {
		t = transform.FindChild("Controller");
		t_2 = transform.FindChild("Controller_2");
		GameObject GameSystem = GameObject.Find("GameSystem");
		gameClearText.SetActive(false);
		nextStage.transform.localScale = new Vector3(0, 0, 0);
		nextStage.SetActive (false);
		clearScore.transform.localScale = new Vector3(0, 0, 0);
		clearScore.SetActive (false);
		clearScore1.transform.localScale = new Vector3(0, 0, 0);
		clearCombo.transform.localScale = new Vector3(0, 0, 0);
		clearTime.transform.localScale = new Vector3(0, 0, 0);
		rankText.transform.localScale = new Vector3(10, 10, 1);

		sucoreRank_2.SetActive(false);
		sucoreRank2_2.SetActive(false);
		comboRank_2.SetActive(false);
		comboRank2_2.SetActive(false);
		timeRank_2.SetActive(false);
		timeRank2_2.SetActive(false);
		yesBtn.SetActive(false);

		sucoreRank_2.transform.localScale = new Vector3(0, 0, 0);
		sucoreRank2_2.transform.localScale = new Vector3(0, 0, 0);
		comboRank_2.transform.localScale = new Vector3(0, 0, 0);
		comboRank2_2.transform.localScale = new Vector3(0, 0, 0);
		timeRank_2.transform.localScale = new Vector3(0, 0, 0);
		timeRank2_2.transform.localScale = new Vector3(0, 0, 0);


		GameObject.Find ("Rank").GetComponent<Text> ().text = "";


	}
	
	// Update is called once per frame
	void Update () {
		if (gaugeNow < 0) gaugeNow = 0.0f;
		iTween.ScaleUpdate (t.gameObject, iTween.Hash ("x", gaugeNow / gaugeMax, "time", 2.0f, "easetype", "easeInCubic"));
		Invoke ("PlayerHP_2", 3.0f);
		if (gaugeNow <= gaugeMax / 2) {
			if (One2) {
				switch (PlayerPrefs.GetInt ("name")) {
				case 1:
					if (GameSystem.stage == 1){ballScript.CharaCutinEnemy3 ();}
					if (GameSystem.stage == 2)ballScript.CharaCutinEnemy ();
					if (GameSystem.stage == 3)ballScript.CharaCutinEnemy2 ();
					break;
				case 2:
					if (GameSystem.stage == 1)ballScript.CharaCutinEnemy ();
					if (GameSystem.stage == 2)ballScript.CharaCutinEnemy2 ();
					if (GameSystem.stage == 3)ballScript.CharaCutinEnemy3 ();
					break;
				case 3:
					if (GameSystem.stage == 1)ballScript.CharaCutinEnemy2 ();
					if (GameSystem.stage == 2)ballScript.CharaCutinEnemy3 ();
					if (GameSystem.stage == 3)ballScript.CharaCutinEnemy ();
					break;
				}
				Invoke ("EnemyCutinFalse", 3.0f);
				One2 = false;

			}
			switch (PlayerPrefs.GetInt ("name")) {
			case 1:
				if (GameSystem.stage == 1){if(i <= 30)Invoke ("EnemyCharaSkill3", 1.0f);}
				if (GameSystem.stage == 2){if(i <= 30)Invoke ("EnemyCharaSkill", 1.0f);}
				if (GameSystem.stage == 3){if(i <= 30)Invoke ("EnemyCharaSkill2", 1.0f);}
				break;
			case 2:
				if (GameSystem.stage == 1){if(i <= 30)Invoke ("EnemyCharaSkill", 1.0f);}
				if (GameSystem.stage == 2){if(i <= 30)Invoke ("EnemyCharaSkill2", 1.0f);}
				if (GameSystem.stage == 3){if(i <= 30)Invoke ("EnemyCharaSkill3", 1.0f);}
				break;
			case 3:
				if (GameSystem.stage == 1){if(i <= 30)Invoke ("EnemyCharaSkill2", 1.0f);}
				if (GameSystem.stage == 2){if(i <= 30)Invoke ("EnemyCharaSkill3", 1.0f);}
				if (GameSystem.stage == 3){if(i <= 30)Invoke ("EnemyCharaSkill+", 1.0f);}
				break;
			}
			if(i <= 15)
			EnemyCharaSkill ();
		}
		if (gaugeNow <= 0) {

			iTween.Stop(TimeScript.TimeGauge);
			if (One) {
				EnemyFadeOut();
				StartCoroutine ("GameClear");
				//GameSystem.stage = GameSystem.stage + 1;
				iTween.MoveFrom(gameClearText, iTween.Hash("x", -700f,"time", 1.5f,"delay", 1f,"isLocal",true));

				One = false;
			}
			ballScript.isPlaying = false;
		}

	}
	private void EnemyCharaSkill () {//お邪魔ドロップ作成
		for(i = 1; i <= 30; i++) {
		GameObject obj = GameObject.Find("Drop0");
		if(obj){ // オブジェクトが取得できたら以下を実行
				iTween.ScaleFrom (obj, iTween.Hash ("x", 2, "y", 2,"time",0.8));
				SpriteRenderer spriteObj = obj.GetComponent<SpriteRenderer> ();
				spriteObj.sprite = ballSprites [0];
				obj.tag = ("EnemyDrop");
				obj.name = "enemyDrop0";
			}
		}
	}
	private void EnemyCharaSkill2 () {//お邪魔ドロップ作成
		for(i = 1; i <= 30; i++) {
			GameObject obj = GameObject.Find("Drop1");
			if(obj){ // オブジェクトが取得できたら以下を実行
				iTween.ScaleFrom (obj, iTween.Hash ("x", 2, "y", 2,"time",0.8));
				SpriteRenderer spriteObj = obj.GetComponent<SpriteRenderer> ();
				spriteObj.sprite = ballSprites [0];
				obj.tag = ("EnemyDrop");
				obj.name = "enemyDrop0";
			}
		}
	}
	private void EnemyCharaSkill3 () {//お邪魔ドロップ作成
		for(i = 1; i <= 30; i++) {
			GameObject obj = GameObject.Find("Drop2");
			if(obj){ // オブジェクトが取得できたら以下を実行
				iTween.ScaleFrom (obj, iTween.Hash ("x", 0.1, "y", 0.1,"time",0.8));
				SpriteRenderer spriteObj = obj.GetComponent<SpriteRenderer> ();
				spriteObj.sprite = ballSprites [0];
				obj.tag = ("EnemyDrop");
				obj.name = "enemyDrop0";
			}
		}
	}
	private void EnemyCutinFalse () {//全てのカットインを非表示にする
		GameObject.Find ("SkillTxst").GetComponent<Text> ().text = "";
		GameObject.Find ("SkillTxst2").GetComponent<Text> ().text = "";
		ballScript.cutinEnemy.SetActive (false);
		ballScript.cutinEnemy_2.SetActive (false);
		ballScript.cutinEnemy_3.SetActive (false);
	}
	public void SetNow(float value) {
		gaugeNow = value;
	}
	
	public void SetMax(float value) {
		gaugeMax = value;
	}
	void PlayerHP_2() {
		iTween.ScaleUpdate (t_2.gameObject, iTween.Hash ("x", gaugeNow / gaugeMax, "time", 3.0f, "easetype", "easeInOutExpo"));
	}

	IEnumerator GameClear () {
		gameClearText.SetActive(true);
		EnemyCount.SetActive (false);
		ScoreScript.clearTime = ((int)TimeScript.time);
		yield return new WaitForSeconds(1.0f);
		GetComponent<AudioSource>().PlayOneShot(gameclearOn);
		yield return new WaitForSeconds(4.0f);
		if (GameSystem.stage == 1) Rank ();
		if (GameSystem.stage == 2) Rank2 ();
		if (GameSystem.stage == 3) Rank3 ();
		ClearScore ();
		yield return new WaitForSeconds(2.0f);
		RankText ();
		iTween.ScaleTo (rankText, iTween.Hash ("x", 1, "y", 1,"time",0.8));


	}
	void GameOverTrue() {
		gameClearText.SetActive(true);
	}
	void EnemyFadeOut() {
		// SetValue()を毎フレーム呼び出して、１秒間に１から０までの値の中間値を渡す
		iTween.FadeTo(GameSystem.damageMotion, iTween.Hash("alpha", 0, "time", 1));
	}
	public void  NextStage(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		clearScore.SetActive(false);
		nextStage.SetActive (true);
		iTween.ScaleTo (nextStage, iTween.Hash ("x", 1, "y", 1,"time",0.3));
		clearScore1.SetActive(false);
		clearCombo.SetActive(false);
		clearTime.SetActive(false);
		GameObject.Find ("Rank").GetComponent<Text> ().text = "";
		sucoreRank_2.SetActive(false);
		sucoreRank2_2.SetActive(false);
		comboRank_2.SetActive(false);
		comboRank2_2.SetActive(false);
		timeRank_2.SetActive(false);
		timeRank2_2.SetActive(false);
		yesBtn.SetActive(false);

	}
	public void  ClearScore(){
		clearScore.SetActive(true);
		iTween.ScaleTo (clearScore, iTween.Hash ("x", 1, "y", 1,"time",0.3));
		GameObject.Find ("ClearScore1").GetComponent<Text> ().text = ScoreScript.clearScore.ToString();
		GameObject.Find ("ClearCombo").GetComponent<Text> ().text = ballScript.comboC.ToString();
		GameObject.Find ("ClearTime").GetComponent<Text> ().text = ScoreScript.clearTime.ToString();//((int)time)
		iTween.ScaleTo (clearScore1, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
		iTween.ScaleTo (clearCombo, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.6));
		iTween.ScaleTo (clearTime, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.8));
		Invoke ("YesBtn", 3.0f);
	}
	public void  YesBtn(){
		yesBtn.SetActive(true);
	}
	public void  Rank(){//ステージ1のスコアランク
		if(ScoreScript.clearScore >= 100000 && ScoreScript.clearScore < 120000){
			rankCount = rankCount + 0;
		} else if(ScoreScript.clearScore >= 120000 && ScoreScript.clearScore < 680000){
			sucoreRank_2.SetActive(true);
			iTween.ScaleTo (sucoreRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8));
			rankCount = rankCount + 1;
		} else if(ScoreScript.clearScore >= 680000){
			sucoreRank_2.SetActive(true);
			sucoreRank2_2.SetActive(true);
			iTween.ScaleTo (sucoreRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8));
			iTween.ScaleTo (sucoreRank2_2, iTween.Hash ("x", 1, "y", 1,"time",0.8));
			rankCount = rankCount + 2;
		}
		if(ballScript.comboC >= 0 && ballScript.comboC < 50){
			rankCount = rankCount + 0;
		} else if(ballScript.comboC >= 50 && ballScript.comboC < 150){
			comboRank_2.SetActive(true);
			iTween.ScaleTo (comboRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.2));
			rankCount = rankCount + 1;
		} else if(ballScript.comboC >= 150){
			comboRank_2.SetActive(true);
			comboRank2_2.SetActive(true);
			iTween.ScaleTo (comboRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.2));
			iTween.ScaleTo (comboRank2_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.2));
			rankCount = rankCount + 2;
		}
		if(ScoreScript.clearTime >= 0 && ScoreScript.clearTime < 15){
			rankCount = rankCount + 0;
		} else if(ScoreScript.clearTime >= 15 && ScoreScript.clearTime < 75){
			timeRank_2.SetActive(true);
			iTween.ScaleTo (timeRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
			rankCount = rankCount + 1;
		} else if(ScoreScript.clearTime >= 75){
			timeRank_2.SetActive(true);
			timeRank2_2.SetActive(true);
			iTween.ScaleTo (timeRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
			iTween.ScaleTo (timeRank2_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
			rankCount = rankCount + 2;
		}

	}
	public void  Rank2(){//ステージ2のスコアランク
		if(ScoreScript.clearScore >= 100000 && ScoreScript.clearScore < 120000){
			rankCount = rankCount + 0;
		} else if(ScoreScript.clearScore >= 120000 && ScoreScript.clearScore < 1500000){
			sucoreRank_2.SetActive(true);
			iTween.ScaleTo (sucoreRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8));
			rankCount = rankCount + 1;
		} else if(ScoreScript.clearScore >= 1500000){
			sucoreRank_2.SetActive(true);
			sucoreRank2_2.SetActive(true);
			iTween.ScaleTo (sucoreRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8));
			iTween.ScaleTo (sucoreRank2_2, iTween.Hash ("x", 1, "y", 1,"time",0.8));
			rankCount = rankCount + 2;
		}
		if(ballScript.comboC >= 0 && ballScript.comboC < 50){
			rankCount = rankCount + 0;
		} else if(ballScript.comboC >= 50 && ballScript.comboC < 200){
			comboRank_2.SetActive(true);
			iTween.ScaleTo (comboRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.2));
			rankCount = rankCount + 1;
		} else if(ballScript.comboC >= 200){
			comboRank_2.SetActive(true);
			comboRank2_2.SetActive(true);
			iTween.ScaleTo (comboRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.2));
			iTween.ScaleTo (comboRank2_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.2));
			rankCount = rankCount + 2;
		}
		if(ScoreScript.clearTime >= 0 && ScoreScript.clearTime < 15){
			rankCount = rankCount + 0;
		} else if(ScoreScript.clearTime >= 15 && ScoreScript.clearTime < 50){
			timeRank_2.SetActive(true);
			iTween.ScaleTo (timeRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
			rankCount = rankCount + 1;
		} else if(ScoreScript.clearTime >= 50){
			timeRank_2.SetActive(true);
			timeRank2_2.SetActive(true);
			iTween.ScaleTo (timeRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
			iTween.ScaleTo (timeRank2_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
			rankCount = rankCount + 2;
		}
		
	}
	public void  Rank3(){//ステージ3のスコアランク
		if(ScoreScript.clearScore >= 100000 && ScoreScript.clearScore < 2000000){
			rankCount = rankCount + 0;
		} else if(ScoreScript.clearScore >=2000000 && ScoreScript.clearScore < 2800000){
			sucoreRank_2.SetActive(true);
			iTween.ScaleTo (sucoreRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8));
			rankCount = rankCount + 1;
		} else if(ScoreScript.clearScore >= 2800000){
			sucoreRank_2.SetActive(true);
			sucoreRank2_2.SetActive(true);
			iTween.ScaleTo (sucoreRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8));
			iTween.ScaleTo (sucoreRank2_2, iTween.Hash ("x", 1, "y", 1,"time",0.8));
			rankCount = rankCount + 2;
		}
		if(ballScript.comboC >= 0 && ballScript.comboC < 300){
			rankCount = rankCount + 0;
		} else if(ballScript.comboC >= 300 && ballScript.comboC < 400){
			comboRank_2.SetActive(true);
			iTween.ScaleTo (comboRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.2));
			rankCount = rankCount + 1;
		} else if(ballScript.comboC >= 400){
			comboRank_2.SetActive(true);
			comboRank2_2.SetActive(true);
			iTween.ScaleTo (comboRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.2));
			iTween.ScaleTo (comboRank2_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.2));
			rankCount = rankCount + 2;
		}
		if(ScoreScript.clearTime >= 0 && ScoreScript.clearTime < 15){
			rankCount = rankCount + 0;
		} else if(ScoreScript.clearTime >= 15 && ScoreScript.clearTime < 20){
			timeRank_2.SetActive(true);
			iTween.ScaleTo (timeRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
			rankCount = rankCount + 1;
		} else if(ScoreScript.clearTime >= 20){
			timeRank_2.SetActive(true);
			timeRank2_2.SetActive(true);
			iTween.ScaleTo (timeRank_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
			iTween.ScaleTo (timeRank2_2, iTween.Hash ("x", 1, "y", 1,"time",0.8,"Delay",0.4));
			rankCount = rankCount + 2;
		}
		
	}
	public void  RankText(){
		if (rankCount >= 1 && rankCount < 2) {
			GameObject.Find ("Rank").GetComponent<Text> ().text = "B";
		} else if (rankCount >= 2 && rankCount < 4) {
			GameObject.Find ("Rank").GetComponent<Text> ().text = "A";
		} else if (rankCount >= 4 && rankCount < 6) {
			GameObject.Find ("Rank").GetComponent<Text> ().text = "S";
		} else if (rankCount >= 6) {
			GameObject.Find ("Rank").GetComponent<Text> ().text = "SS";
		}
	}










}