//今村.
using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public clear clear;
	public goal goal;
	public float speed = 50;

	void Start() {
	}

	void Update () {
		// 左へ移動
		transform.position += Vector3.left * speed * Time.deltaTime* Countdown.x;
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player")
		{
			if(name == "te"){
				goal.goalScore = goal.goalScore + 14;
				clear.Right = true;
			}
			if(name == "te2"){
				goal.goalScore = goal.goalScore + 14;
				clear.Left = true;
			}
			if(name == "ganmen"){
				goal.goalScore = goal.goalScore + 14;
				clear.Kao = true;
			}
			if(name == "マフラー"){
				goal.goalScore = goal.goalScore + 14;
				clear.Mahu = true;
			}
			if(name == "baketu"){
				goal.goalScore = goal.goalScore + 14;
				clear.Baketu = true;
			}
			if(name == "botan"){
				goal.goalScore = goal.goalScore + 14;//84
				clear.Botan = true;
			}
			Destroy (gameObject);
		}
	}

}
