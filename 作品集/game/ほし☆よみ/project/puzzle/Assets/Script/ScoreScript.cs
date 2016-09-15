using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	private float time = 5;
	
	private int score = 0;
	public int combo = 0;
	public int comboSkill = 0;
	private int count = 0;
	private int damage = 0;

	public int clearScore = 0;
	public int clearCombo = 30;
	public float clearTime = 0;


	private GameObject Combo;
	private GameObject Combo2;
	private GameObject Damage;
	
	void Start () {

		//初期スコア(0点)を表示
		GameObject.Find ("Score").GetComponent<Text> ().text = "Score: " + score.ToString();
		GameObject.Find ("Combo").GetComponent<Text> ().text = "";
		GameObject.Find ("Combo2").GetComponent<Text> ().text = "";
		Combo = GameObject.Find ("Combo");
		GameObject.Find ("Count").GetComponent<Text> ().text = "";
		GameObject.Find ("Damage").GetComponent<Text> ().text = "";
		Damage = GameObject.Find ("Damage");

		GameObject.Find ("ClearScore1").GetComponent<Text> ().text = "";
		GameObject.Find ("ClearCombo").GetComponent<Text> ().text = "";
		GameObject.Find ("ClearTime").GetComponent<Text> ().text = "";

	}
	void Update () {

	}

	//GameSystemからSendMessageで呼ばれるスコア加算用メソッド
	public void AddPoint (int point) {
		score = score + point;
		clearScore = clearScore + point;
		GetComponent<Text>().text = "Score: " + score.ToString();
	}
	public void AddCombo (int point) {
		combo = combo + point;
		comboSkill = comboSkill + point;
	//	if(clearCombo < combo)clearCombo = combo;
		GameObject.Find ("Combo").GetComponent<Text> ().text =  combo.ToString();
		iTween.ScaleFrom (Combo, iTween.Hash ("y", 0,"time",0.5));
		GameObject.Find ("Combo2").GetComponent<Text> ().text = "combo";
	}
	public void RemoveCombo () {
		GameObject.Find ("Combo").GetComponent<Text> ().text = "";
		GameObject.Find ("Combo2").GetComponent<Text> ().text = "";
		combo = 0;
		comboSkill = 0;
	}
	public void AddCount (int point) {
		count =  point;
		GameObject.Find ("Count").GetComponent<Text> ().text = count.ToString() + "chain";
	}
	public void RemoveCount () {
		count = 0;
		GameObject.Find ("Count").GetComponent<Text> ().text = count.ToString() + "chain";
	}
	public void AddDamage (int point) {
		damage =  point;
		GetComponent<Text>().text =  "-" + damage.ToString();
		//iTween.MoveFrom(damage, iTween.Hash("x", -700f,"time", 1.5f,"delay", 1f,"isLocal",true));

	}
	public void RemoveDamage () {
		GameObject.Find ("Damage").GetComponent<Text> ().text = "";
	}
	public void Rank () {

	}


	/*public void FalseCombo () {
		Combo.SetActive (false);
	}*/
}