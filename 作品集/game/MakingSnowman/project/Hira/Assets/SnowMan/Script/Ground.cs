//今村.
using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	public Player Player;
	public float speed = 50;
	void Update () {
		// 左へ移動
		//speed = 50 + Player.player_x;
		transform.position += Vector3.left * speed * Time.deltaTime * Countdown.x * (Player.player_x * 1.5f);
	}
}
