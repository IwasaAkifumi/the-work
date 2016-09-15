//今村.
using UnityEngine;
using System.Collections;

public class Enemy_Ground : MonoBehaviour {
	SpriteRenderer MainSpriteRenderer;
	// publicで宣言し、inspectorで設定可能にする
	public Sprite q01Sprite;
	public Sprite q02Sprite;
	public Sprite q03Sprite;
	public Sprite q04Sprite;
	public Sprite q05Sprite;
	public Sprite q06Sprite;
	public Sprite q07Sprite;
	public Sprite q08Sprite;
	public float speed = 8;
	static public int x,y,time;
	static public float z;
	void Start ()
	{
		x = 0;
		y = 0;
		time = 0;
		// このobjectのSpriteRendererを取得
		MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void Update () {
		Change ();
	}
	void OnBecameVisible ()	{
		time =1;
		x = 0;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player")
		{
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
			Destroy(gameObject);
		}
	}
	void Change(){
		if(time ==1 ){
			y++;
		}
		if(17<=y){
			MainSpriteRenderer.sprite = q02Sprite;
		}
		if(34<=y){
			MainSpriteRenderer.sprite = q03Sprite;
		}
		if(51<=y){
			MainSpriteRenderer.sprite = q04Sprite;
		}
		if(68<=y){
			MainSpriteRenderer.sprite = q05Sprite;
		}
		if(85<=y){
			MainSpriteRenderer.sprite = q06Sprite;
		}
		if(102<=y){
			MainSpriteRenderer.sprite = q07Sprite;
		}
		if(129<=y){
			MainSpriteRenderer.sprite = q08Sprite;
		}
		transform.position += Vector3.left * speed * Time.deltaTime * Countdown.x;
		z = transform.position.x;
		if (z <= 24 && 20 <= z) {
			Assert2.m_pos.z = -3;
			
			Assert2.y=1;
		}
	}
}
