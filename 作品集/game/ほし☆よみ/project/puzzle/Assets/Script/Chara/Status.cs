using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {
	
	public int Attack;
	public int Block;
	public int Hp = 650;
	
	public int PostAttack(){
		return Attack;
	}
	public int PostBlock(){
		return Block;
	}
	public int PostHp(){
		return Hp;
	}
}