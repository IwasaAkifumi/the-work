//今村.
using UnityEngine;
using System.Collections;

public class Enemy_Stop : MonoBehaviour {

	public Player Player;
	public EnemySize EnemySize;
	public float speed = 8;
	static public int x=0;
	static public float z;
	public GameObject Player2;
	public float enemy_Size = 999.0f;

	void Start () {
		GameObject Player = GameObject.Find ("yuki");
	}

	void Update () {
		// 左へ移動
		//speed = speed + Player.player_x;
		transform.position += Vector3.left * speed * Time.deltaTime * Countdown.x * (Player.player_x * 1.5f);

		}
	void OnBecameVisible () 
	{
		x = 0;
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player")
		{
			//Score.enemy++;
			if(RunBodyScript.m_pos.z == 10 && RunRightArmScript.m_pos.z == 10 && RunLeftArmScript.m_pos.z == 10 && RunHeadScript.m_pos.z == 10 && RunLegScript.m_pos.z == 10 &&x==0){
				RunCami.m_pos.z = 10;
				RunSkirt.m_pos.z = 10;
				RunBlouse.m_pos.z = 10;
				RunShoes.m_pos.z = 10;
				CharaBackShoes.m_pos.z = 10;
				CharaBackCami.m_pos.z = 10;
				CharaBackSkirt.m_pos.z = 10;
				CharaBackBlouse.m_pos.z = 10;
				x=1;
			}
			//
			if(RunBodyScript.m_pos.z == -2 && RunRightArmScript.m_pos.z == 10 && RunLeftArmScript.m_pos.z == 10 && RunHeadScript.m_pos.z == 10 && RunLegScript.m_pos.z == 10 &&x==0){
				RunBodyScript.m_pos.z = 10;
				CharaBackBody.m_pos.z = 10;
				CharaBackUnder.m_pos.z = -1;
				x=1;
				GameButton.Body1 = 0;
			}
			if(RunHeadScript.m_pos.z == -4 && RunBodyScript.m_pos.z == 10 && RunRightArmScript.m_pos.z == 10 && RunLeftArmScript.m_pos.z == 10 && RunLegScript.m_pos.z == 10 &&x==0){
				RunHeadScript.m_pos.z = 10;
				RunHair.m_pos.z = -4;
				CharaBackHead.m_pos.z = 10;
				GameButton.Head1 = 0;
				x=1;
			}
			if(RunLegScript.m_pos.z == -1 && RunBodyScript.m_pos.z == 10 && RunRightArmScript.m_pos.z == 10 && RunLeftArmScript.m_pos.z == 10 && RunHeadScript.m_pos.z == 10 &&x==0){
				RunBodyScript.m_pos.z = 10;
				CharaBackBody.m_pos.z = 10;
				CharaBackUnder.m_pos.z = -1;
				x=1;
				GameButton.Leg1 = 0;
			}
			if(RunRightArmScript.m_pos.z == -5 && RunLeftArmScript.m_pos.z == 0 && RunBodyScript.m_pos.z == 10 && RunHeadScript.m_pos.z == 10 && RunLegScript.m_pos.z == 10 &&x==0){
				RunRightArmScript.m_pos.z = 10;
				RunLeftArmScript.m_pos.z = 10;
				CharaBackLeftArm.m_pos.z = 10;
				CharaBackRightArm.m_pos.z = 10;
				GameButton.Arm1= 0;
				x=1;
			}
			//
			if(RunBodyScript.m_pos.z == -2 && RunLegScript.m_pos.z == -1 && RunRightArmScript.m_pos.z == 10 && RunLeftArmScript.m_pos.z == 10 && RunHeadScript.m_pos.z == 10&&x==0){
				RunBodyScript.m_pos.z = 10;
				CharaBackBody.m_pos.z = 10;
				CharaBackUnder.m_pos.z = -1;
				x=1;
				GameButton.Body1 = 0;
			}
			if(RunBodyScript.m_pos.z == -2 && RunHeadScript.m_pos.z == -4 && RunRightArmScript.m_pos.z == 10 && RunLeftArmScript.m_pos.z == 10 && RunHeadScript.m_pos.z == 10&&x==0){
				RunBodyScript.m_pos.z = 10;
				CharaBackBody.m_pos.z = 10;
				CharaBackUnder.m_pos.z = -1;
				x=1;
				GameButton.Body1 = 0;
			}
			if(RunBodyScript.m_pos.z == -2 && RunRightArmScript.m_pos.z == -5 && RunLeftArmScript.m_pos.z == 0 && RunLegScript.m_pos.z == 10 && RunHeadScript.m_pos.z == 10 &&x==0){
				RunBodyScript.m_pos.z = 10;
				CharaBackBody.m_pos.z = 10;
				CharaBackUnder.m_pos.z = -1;
				x=1;
				GameButton.Body1 = 0;
			}
			if(RunRightArmScript.m_pos.z == -5 && RunLeftArmScript.m_pos.z == 0 && RunLegScript.m_pos.z == -1 && RunHeadScript.m_pos.z == 10 && RunBodyScript.m_pos.z == 10 &&x==0){
				RunLegScript.m_pos.z = 10;
				CharaBackLeg.m_pos.z = 10;
				x=1;
				GameButton.Leg1 = 0;
			}
			if(RunRightArmScript.m_pos.z == -5 && RunLeftArmScript.m_pos.z == 0 && RunHeadScript.m_pos.z == -4 && RunLegScript.m_pos.z == 10 && RunBodyScript.m_pos.z == 10 &&x==0){
				RunRightArmScript.m_pos.z = 10;
				RunLeftArmScript.m_pos.z = 10;
				CharaBackLeftArm.m_pos.z = 10;
				CharaBackRightArm.m_pos.z = 10;
				x=1;
				GameButton.Arm1= 0;
			}
			if(RunLegScript.m_pos.z == -1 && RunHeadScript.m_pos.z == -4 &&  RunBodyScript.m_pos.z == 10 && RunRightArmScript.m_pos.z == 10 && RunLeftArmScript.m_pos.z == 10 &&x==0){
				RunLegScript.m_pos.z = 10;
				CharaBackLeg.m_pos.z = 10;
				x=1;
				GameButton.Leg1 = 0;
			}
			//
			if(RunBodyScript.m_pos.z == -2 && RunLegScript.m_pos.z == -1 && RunRightArmScript.m_pos.z == -5 && RunLeftArmScript.m_pos.z == 0 && RunHeadScript.m_pos.z == 10&&x==0){
				RunBodyScript.m_pos.z = 10;
				CharaBackBody.m_pos.z = 10;
				CharaBackUnder.m_pos.z = -1;
				x=1;
				GameButton.Body1 = 0;
			}
			if(RunBodyScript.m_pos.z == -2 && RunLegScript.m_pos.z == 10 && RunRightArmScript.m_pos.z == -5 && RunLeftArmScript.m_pos.z == 0 && RunHeadScript.m_pos.z == -4&&x==0){
				RunBodyScript.m_pos.z = 10;
				CharaBackBody.m_pos.z = 10;
				CharaBackUnder.m_pos.z = -1;
				x=1;
				GameButton.Body1 = 0;
			}
			if(RunBodyScript.m_pos.z == -2 && RunLegScript.m_pos.z == -1 && RunRightArmScript.m_pos.z == 10 && RunLeftArmScript.m_pos.z == 10 && RunHeadScript.m_pos.z == -4&&x==0){
				RunBodyScript.m_pos.z = 10;
				CharaBackBody.m_pos.z = 10;
				CharaBackUnder.m_pos.z = -1;
				x=1;
				GameButton.Body1 = 0;
			}
			if(RunBodyScript.m_pos.z == 10 && RunLegScript.m_pos.z == -1 && RunRightArmScript.m_pos.z == -5 && RunLeftArmScript.m_pos.z == 0 && RunHeadScript.m_pos.z == -4&&x==0){
				RunLegScript.m_pos.z = 10;
				CharaBackLeg.m_pos.z = 10;
				x=1;
				GameButton.Leg1 = 0;
			}
			//
			if(RunBodyScript.m_pos.z == -2 && RunLegScript.m_pos.z == -1 && RunRightArmScript.m_pos.z == -5 && RunLeftArmScript.m_pos.z == 0 && RunHeadScript.m_pos.z == -4&&x==0){
				RunBodyScript.m_pos.z = 10;
				CharaBackBody.m_pos.z = 10;
				CharaBackUnder.m_pos.z = -1;
				x=1;
				GameButton.Body1 = 0;
			}
			coll.gameObject.SendMessage("EnemySize_P", enemy_Size);
			Destroy(gameObject);

		}
		if (coll.gameObject.tag == "WallEnemy") {
			Destroy(gameObject);
		}

	}
}
