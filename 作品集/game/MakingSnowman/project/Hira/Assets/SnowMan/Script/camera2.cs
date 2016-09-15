using UnityEngine;
using System.Collections;

public class camera2 : MonoBehaviour {
	public Player Player;
	public GameObject player2;
	
	private	Vector3			position_offset = Vector3.zero;
	private Vector3			move_vector = Vector3.zero;					// 前のフレームからの移動量.
	
	// ================================================================ //
	// MonoBehaviour からの継承.
	
	void	Start()
	{
	//	this.player = GameObject.FindGameObjectWithTag("yuki");
		
		// プレイヤーとカメラのポジションのオフセット（位置のずれ）を求めておく.
		// プレイヤーと一緒に移動するようにするため.
		this.position_offset = this.transform.position - this.player2.transform.position;
	}
	
	void	Update ()
	{
		
	}
	
	void	LateUpdate()
	{
		if (!Player.playing) {
			// プレイヤーと一緒に移動する.
		
			Vector3 new_position = this.transform.position;
		
			//new_position.x = this.player.transform.position.x + this.position_offset.x;
		
			new_position.y = this.player2.transform.position.y + this.position_offset.y;
		
		
			this.move_vector = (new_position - this.transform.position) / Time.deltaTime;
		
			this.transform.position = new_position;
		}
	}

	
	public Vector3	getMoveVector()
	{
		return(this.move_vector);
	}
}
