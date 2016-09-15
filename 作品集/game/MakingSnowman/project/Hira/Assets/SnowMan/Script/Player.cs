using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public Enemy_Stop Enemy_Stop;
	public EnemySize EnemySize;
	public ballRun ballRun;
	public goal goal;

	private GUIStyle labelStyle;
	public float player_x;
	public float player_x_size;
	public float player_y;
	public float player_z;
	public float size = 0.0f;
	public GameObject sizeoj;
	private float p_position = 0.0f;
	private float s = 10000.0f;
	public float okkiku;
	public GameObject GameOver;

	public bool playing = true;

	// Use this for initialization
	void Start () {
		//GameObject.Find ("Snow_Size").GetComponent<Text> ().text = "大きさ: " + player_x.ToString();
	//	GameObject.Find ("Enemy_Size").GetComponent<Text> ().text = "敵: " + size.ToString();
		player_x = 0.5f;
		player_y = 0.5f;
		player_z = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (goal.Goal) {
			if (ballRun.x_position >= 0) {
				p_position = ballRun.x_position;
			}
			if (ballRun.x_position < 0) {
				p_position = 0;
			}
			if (player_x <= 2) {
				okkiku = 1 / (player_x * player_x);
				Debug.Log (p_position);
				player_x = player_x + 0.0005f * okkiku + (0.001f * p_position / 7 * okkiku);
				player_y = player_y + 0.0005f * okkiku + (0.001f * p_position / 7 * okkiku);
				player_z = player_z + 0.001f + p_position / s;
				player_x_size = player_x * 10;
				//GameObject.Find ("Snow_Size").GetComponent<Text> ().text = "大きさ: " + ((int)player_x_size).ToString ();
				this.transform.localScale = new Vector3 (player_x, player_y, player_z);
			}
			if (player_x > 2) {
				player_x = 2f;
				player_y = 2f;
				player_z = 2f;
				//GameObject.Find ("Snow_Size").GetComponent<Text> ().text = "大きさ:MAX " ;
			}
			if (player_x < 0f) {
				player_x = 0f;
				player_y = 0f;
				player_z = 0f;

			}
		}
		transform.Rotate (new Vector3 (0f, 0f, -20f / player_x-p_position));//回転
	}
	public void EnemySize_P (int point) {
		size =  point;
		Debug.Log(size);
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "EnemyBig") {
			//	EnemySize.enemySize = gameObject.Enemy_Stop.enemy_Size;
			if (player_x_size >= size) {//自分が大きかったら
				player_x = player_x + 0.02f;
				player_y = player_y + 0.02f;
				//Destroy (gameObject);
			}
			if (player_x_size < size) {//自分が小さかったら
				Handheld.Vibrate ();
				player_x = player_x - 0.1f;
				player_y = player_y - 0.1f;
				//Destroy (gameObject);
			}
		}

		if (coll.gameObject.tag == "Enemy") {
			if (player_x_size < size) {
				Handheld.Vibrate ();
				player_x = player_x / 2f;
				player_y = player_y / 2f;
			}
		}
		/*if (coll.gameObject.tag == "WallEnemy") {
			playing = true;
			Destroy (gameObject);
		}*/
	}
}
