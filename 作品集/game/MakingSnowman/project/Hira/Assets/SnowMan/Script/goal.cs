using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class goal : MonoBehaviour {
	public GameObject GameClear;
	public GameObject back;
	public Score Score;
	public Player Player;
	public GameObject yuki;
	public int s;
	public bool Goal = true;
	public float goalScore = 0;
	// Use this for initialization
	void Start () {
		Goal = true;
		goalScore = 0;
		GameObject.Find ("Goal_Time").GetComponent<Text> ().text = "";
		GameObject.Find ("Goal_Score").GetComponent<Text> ().text = "";
		GameObject.Find ("GOAL").GetComponent<Text> ().text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			GameObject.Find ("GOAL").GetComponent<Text> ().text = "GOAL";
			if(Player.player_x >= 1.3 && Player.player_x <= 1.7){
				goalScore = goalScore+16;
			}
			if(Player.player_x >= 1.7 && Player.player_x <= 2.0){
				goalScore = goalScore+15;
			}
			if(Player.player_x >= 1.0 && Player.player_x <= 1.3){
				goalScore = goalScore+10;
			}
			if(Player.player_x >= 0.6 && Player.player_x <= 1.0){
				goalScore = goalScore+5;
			}
			if(Player.player_x <= 0.6){
				goalScore = goalScore+2;
			}
			s = Score.y;
			Invoke("GameClear_s",3);


		}
	}

	public void  GameClear_s(){
		GameClear.SetActive (true);
		GameObject.Find ("GOAL").GetComponent<Text> ().text = "";
		GameObject.Find ("Goal_Score").GetComponent<Text> ().text = "完成度：" + goalScore.ToString();
		GameObject.Find ("Goal_Time").GetComponent<Text> ().text = "タイム：" + s.ToString();
		PlayerPrefs.SetInt("goalScore",10);
		Goal = false;
	}

	public void  Retry(){
		FadeManager.Instance.LoadLevel("One",1.0f);
	}
}
